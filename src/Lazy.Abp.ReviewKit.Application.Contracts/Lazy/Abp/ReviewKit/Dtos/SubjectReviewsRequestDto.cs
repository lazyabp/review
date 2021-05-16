using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Lazy.Abp.ReviewKit.Dtos
{
    public class SubjectReviewsRequestDto : PagedAndSortedResultRequestDto
    {
        public string ModuleName { get; set; }

        public string SubjectId { get; set; }
    }
}
