using LazyAbp.ReviewKit.Admin.Dtos;
using LazyAbp.ReviewKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyAbp.ReviewKit.Admin
{
    public class ReviewManagementAppService : CrudAppService<Review, ReviewDto, Guid, GetReviewListRequestDto, CreateUpdateReviewDto, CreateUpdateReviewDto>,
        IReviewManagementAppService
    {
        protected override string GetPolicyName { get; set; } = ReviewKitAdminPermissions.Review.Default;
        protected override string GetListPolicyName { get; set; } = ReviewKitAdminPermissions.Review.Default;
        protected override string CreatePolicyName { get; set; } = ReviewKitAdminPermissions.Review.Create;
        protected override string UpdatePolicyName { get; set; } = ReviewKitAdminPermissions.Review.Update;
        protected override string DeletePolicyName { get; set; } = ReviewKitAdminPermissions.Review.Delete;

        private readonly IReviewRepository _repository;

        public ReviewManagementAppService(IReviewRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<PagedResultDto<ReviewDto>> GetListAsync(GetReviewListRequestDto input)
        {
            var totalCount = await _repository.GetCountAsync(input.UserId, input.ModuleName,
                    input.SubjectId, input.ParentId, input.RootId, input.Status, input.Filter, false);

            var list = await _repository.GetListAsync(input.UserId, input.ModuleName, input.SubjectId,
                    input.ParentId, input.RootId, input.Status, input.Filter, false, input.MaxResultCount, input.SkipCount, input.Sorting);

            return new PagedResultDto<ReviewDto>(
                totalCount,
                ObjectMapper.Map<List<Review>, List<ReviewDto>>(list)
            );
        }

        public override Task<ReviewDto> CreateAsync(CreateUpdateReviewDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewDto> AuditAsync(Guid id, AuditRequedtDto input)
        {
            var review = await _repository.GetAsync(id);

            review.Audit(input.Status, input.Remark);

            return ObjectMapper.Map<Review, ReviewDto>(review);
        }
    }
}
