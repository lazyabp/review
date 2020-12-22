using System;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.ReviewKit.Dtos
{
    [Serializable]
    public class ReviewDto : FullAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }

        public string ModuleName { get; set; }

        public string SubjectId { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? RootId { get; set; }

        public string Content { get; set; }

        public int LikeCount { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public AuditStatus Status { get; set; }

        public string AuditRemark { get; set; }
    }
}