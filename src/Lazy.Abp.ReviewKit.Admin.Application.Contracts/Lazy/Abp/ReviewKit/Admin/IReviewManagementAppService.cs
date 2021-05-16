using Lazy.Abp.ReviewKit.Admin.Dtos;
using Lazy.Abp.ReviewKit.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.ReviewKit.Admin
{
    public interface IReviewManagementAppService :
        ICrudAppService<
            ReviewDto,
            Guid,
            ReviewListRequestDto,
            ReviewCreateUpdateDto,
            ReviewCreateUpdateDto>
    {
        Task<ReviewDto> AuditAsync(Guid id, AuditRequedtDto input);
    }
}
