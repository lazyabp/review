using LazyAbp.ReviewKit.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.ReviewKit
{
    [RemoteService(Name = ReviewKitRemoteServiceConsts.RemoteServiceName)]
    [Area("reviewkit")]
    [ControllerName("Review")]
    [Route("api/reviewkit/reviews")]
    public class ReviewController : ReviewKitController, IReviewAppService
    {
        private readonly IReviewAppService _service;

        public ReviewController(IReviewAppService service)
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
        public Task<PagedResultDto<ReviewDto>> GetListAsync(GetReviewListRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpGet]
        [Route("by-subject")]
        public Task<PagedResultDto<ReviewViewDto>> GetSubjectReviewsAsync(GetSubectReviewsRequestDto input)
        {
            return _service.GetSubjectReviewsAsync(input);
        }

        [HttpPost]
        public Task<ReviewDto> CreateAsync(CreateUpdateReviewDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ReviewDto> UpdateAsync(Guid id, CreateUpdateReviewDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpPut]
        [Route("{id}/toggle-like")]
        public Task<int> ToggleLikeAsync(Guid id)
        {
            return _service.ToggleLikeAsync(id);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
    }
}
