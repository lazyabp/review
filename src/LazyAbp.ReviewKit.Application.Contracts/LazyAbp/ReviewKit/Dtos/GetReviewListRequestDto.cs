using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.ReviewKit.Dtos
{
    public class GetReviewListRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? UserId { get; set; }

        public string ModuleName { get; set; }

        public string SubjectId { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? RootId { get; set; }

        public AuditStatus? Status { get; set; }

        public string Filter { get; set; }
    }
}
