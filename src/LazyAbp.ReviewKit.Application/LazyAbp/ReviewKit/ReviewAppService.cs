using System;
using LazyAbp.ReviewKit.Permissions;
using LazyAbp.ReviewKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Users;
using Volo.Abp;
using System.Collections.Generic;
using System.Linq;

namespace LazyAbp.ReviewKit
{
    public class ReviewAppService : ReviewKitAppService, IReviewAppService
    {
        private readonly IReviewRepository _repository;
        private readonly IReviewLikeRepository _reviewLikeRepository;

        public ReviewAppService(IReviewRepository repository,
            IReviewLikeRepository reviewLikeRepository)
        {
            _repository = repository;
            _reviewLikeRepository = reviewLikeRepository;
        }

        public async Task<ReviewDto> GetAsync(Guid id)
        {
            var review = await _repository.GetAsync(id);

            return ObjectMapper.Map<Review, ReviewDto>(review);
        }

        public async Task<PagedResultDto<ReviewDto>> GetListAsync(GetReviewListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(CurrentUser.GetId(), input.ModuleName,
                    input.SubjectId, input.ParentId, input.RootId, input.Status, input.Filter, false);

            var list = await _repository.GetListAsync(CurrentUser.GetId(), input.ModuleName, input.SubjectId, 
                    input.ParentId, input.RootId, input.Status, input.Filter, false, input.MaxResultCount, input.SkipCount, input.Sorting);

            return new PagedResultDto<ReviewDto>(
                totalCount,
                ObjectMapper.Map<List<Review>, List<ReviewDto>>(list)
            );
        }

        /// <summary>
        /// 返回树形结构的评论
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<ReviewViewDto>> GetSubjectReviewsAsync(GetSubectReviewsRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(null, input.ModuleName, input.SubjectId, null, null, AuditStatus.Passed, null, true);

            var list = await _repository.GetListAsync(null, input.ModuleName, input.SubjectId, null, null, 
                    AuditStatus.Passed, null, true, input.MaxResultCount, input.SkipCount, input.Sorting);

            var parentIds = list.Select(x => x.Id).ToList();
            var childrens = await _repository.GetByRootAsync(parentIds, AuditStatus.Passed);
            var reviews = ObjectMapper.Map<List<Review>, List<ReviewViewDto>>(list);

            foreach(var review in reviews)
            {
                review.Childrens = GetChildrens(childrens, review.Id);
            }

            return new PagedResultDto<ReviewViewDto>(totalCount, reviews);
        }

        public async Task<ReviewDto> CreateAsync(CreateUpdateReviewDto input)
        {
            Guid? rootId = null;
            string ipAddress = "", userAgent = "";
            if (input.ParentId.HasValue)
            {
                var parent = await _repository.GetAsync(input.ParentId.Value);

                rootId = parent.ParentId.HasValue ? parent.RootId : parent.Id;
            }

            var review = new Review(GuidGenerator.Create(), CurrentUser.TenantId, CurrentUser.GetId(), input.ModuleName, input.SubjectId, input.ParentId, rootId, input.Content, ipAddress, userAgent);

            review = await _repository.InsertAsync(review);

            return ObjectMapper.Map<Review, ReviewDto>(review);
        }

        public async Task<ReviewDto> UpdateAsync(Guid id, CreateUpdateReviewDto input)
        {
            var review = await _repository.GetAsync(id);
            if (review.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissons"]);

            review.Update(input.Content);

            return ObjectMapper.Map<Review, ReviewDto>(review);
        }

        public async Task<int> ToggleLikeAsync(Guid id)
        {
            var review = await _repository.GetAsync(id);
            var reviewLike = await _reviewLikeRepository.GetUserReviewLikeAsync(CurrentUser.GetId(), id);
            if (reviewLike != null)
            {
                // 取消点赞
                if (reviewLike.IsLike)
                {
                    reviewLike.SetLike(false);
                    review.ToggleLike(false);
                }
                else
                // 重新点赞
                {
                    reviewLike.SetLike(true);
                    review.ToggleLike(true);
                }

                await _reviewLikeRepository.UpdateAsync(reviewLike);
                review = await _repository.UpdateAsync(review);

                return review.LikeCount;
            }

            await _reviewLikeRepository.InsertAsync(new ReviewLike(GuidGenerator.Create(), id, CurrentUser.GetId(), true));

            review.ToggleLike(true);
            review = await _repository.UpdateAsync(review);

            return review.LikeCount;
        }

        public async Task DeleteAsync(Guid id)
        {
            var review = await _repository.GetAsync(id);
            if (review.UserId != CurrentUser.GetId())
                throw new UserFriendlyException(L["NoPermissons"]);

            await _repository.DeleteAsync(review);
        }
    
        /// <summary>
        /// 评论树
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<ReviewViewDto> GetChildrens(List<Review> haystack, Guid parentId)
        {
            var result = new List<ReviewViewDto>();

            foreach(var item in haystack.Where(q => q.ParentId == parentId))
            {
                var review = ObjectMapper.Map<Review, ReviewViewDto>(item);
                result.Add(review);

                // 遍历子节点
                review.Childrens = GetChildrens(haystack, item.Id);
            }

            return result;
        }
    }
}
