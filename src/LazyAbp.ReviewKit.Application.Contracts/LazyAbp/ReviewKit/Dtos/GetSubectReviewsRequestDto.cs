using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.ReviewKit.Dtos
{
    public class GetSubectReviewsRequestDto : PagedAndSortedResultRequestDto
    {
        public string ModuleName { get; set; }

        public string SubjectId { get; set; }
    }
}
