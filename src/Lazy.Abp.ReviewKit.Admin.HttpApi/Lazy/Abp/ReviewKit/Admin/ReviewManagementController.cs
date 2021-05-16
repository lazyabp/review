using Lazy.Abp.ReviewKit.Admin.Dtos;
using Lazy.Abp.ReviewKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.ReviewKit.Admin
{
    [RemoteService(Name = ReviewKitAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("reviewkitadmin")]
    [ControllerName("Review")]
    [Route("api/reviewkit/reviews/admin")]
    public class ReviewManagementController : AbpController, IReviewManagementAppService
    {
        private readonly IReviewManagementAppService _service;

        public ReviewManagementController(IReviewManagementAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ReviewDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ReviewDto>> GetListAsync(ReviewListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<ReviewDto> CreateAsync(ReviewCreateUpdateDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ReviewDto> UpdateAsync(Guid id, ReviewCreateUpdateDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/audit")]
        public Task<ReviewDto> AuditAsync(Guid id, AuditRequedtDto input)
        {
            return _service.AuditAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
