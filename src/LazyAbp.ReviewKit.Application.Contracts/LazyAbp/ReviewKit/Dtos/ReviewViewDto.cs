using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace LazyAbp.ReviewKit.Dtos
{
    [Serializable]
    public class ReviewViewDto : CreationAuditedEntityDto<Guid>
    {
        public Guid? UserId { get; set; }

        //public string ModuleName { get; set; }

        //public string SubjectId { get; set; }

        //public Guid? ParentId { get; set; }

        //public Guid? RootId { get; set; }

        public string Content { get; set; }

        public int LikeCount { get; set; }

        public List<ReviewViewDto> Childrens { get; set; }
    }
}