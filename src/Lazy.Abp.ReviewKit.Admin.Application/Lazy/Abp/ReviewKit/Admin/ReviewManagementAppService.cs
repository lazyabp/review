using Lazy.Abp.ReviewKit.Admin.Dtos;
using Lazy.Abp.ReviewKit.Dtos;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.ReviewKit.Admin
{
    public class ReviewManagementAppService : CrudAppService<Review, ReviewDto, Guid, ReviewListRequestDto, ReviewCreateUpdateDto, ReviewCreateUpdateDto>,
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

        [Authorize(ReviewKitAdminPermissions.Review.Default)]
        public override async Task<PagedResultDto<ReviewDto>> GetListAsync(ReviewListRequestDto input)
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

        public override Task<ReviewDto> CreateAsync(ReviewCreateUpdateDto input)
        {
            throw new NotImplementedException();
        }

        [Authorize(ReviewKitAdminPermissions.Review.Audit)]
        public async Task<ReviewDto> AuditAsync(Guid id, AuditRequedtDto input)
        {
            var review = await _repository.GetAsync(id);

            review.Audit(input.Status, input.Remark);

            return ObjectMapper.Map<Review, ReviewDto>(review);
        }
    }
}
