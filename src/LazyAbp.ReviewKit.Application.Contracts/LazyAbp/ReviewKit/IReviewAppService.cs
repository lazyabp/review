using System;
using System.Threading.Tasks;
using LazyAbp.ReviewKit.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LazyAbp.ReviewKit
{
    public interface IReviewAppService : IApplicationService, ITransientDependency
    {
        Task<ReviewDto> GetAsync(Guid id);

        Task<PagedResultDto<ReviewDto>> GetListAsync(GetReviewListRequestDto input);

        /// <summary>
        /// 返回树形结构的评论
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ReviewViewDto>> GetSubjectReviewsAsync(GetSubectReviewsRequestDto input);

        Task<ReviewDto> CreateAsync(CreateUpdateReviewDto input);

        Task<ReviewDto> UpdateAsync(Guid id, CreateUpdateReviewDto input);

        Task<int> ToggleLikeAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}