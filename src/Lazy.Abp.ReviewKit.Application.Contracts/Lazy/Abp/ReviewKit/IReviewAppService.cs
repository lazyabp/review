using System;
using System.Threading.Tasks;
using Lazy.Abp.ReviewKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Lazy.Abp.ReviewKit
{
    public interface IReviewAppService : IApplicationService, ITransientDependency
    {
        Task<ReviewDto> GetAsync(Guid id);

        Task<PagedResultDto<ReviewDto>> GetListAsync(ReviewListRequestDto input);

        /// <summary>
        /// 返回树形结构的评论
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ReviewViewDto>> GetSubjectReviewsAsync(SubjectReviewsRequestDto input);

        Task<ReviewDto> CreateAsync(ReviewCreateUpdateDto input);

        Task<ReviewDto> UpdateAsync(Guid id, ReviewCreateUpdateDto input);

        Task<int> ToggleLikeAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}