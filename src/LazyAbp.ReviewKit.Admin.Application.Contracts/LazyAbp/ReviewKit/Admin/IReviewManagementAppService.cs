using LazyAbp.ReviewKit.Admin.Dtos;
using LazyAbp.ReviewKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LazyAbp.ReviewKit.Admin
{
    public interface IReviewManagementAppService :
        ICrudAppService<
            ReviewDto,
            Guid,
            GetReviewListRequestDto,
            CreateUpdateReviewDto,
            CreateUpdateReviewDto>
    {
        Task<ReviewDto> AuditAsync(Guid id, AuditRequedtDto input);
    }
}
