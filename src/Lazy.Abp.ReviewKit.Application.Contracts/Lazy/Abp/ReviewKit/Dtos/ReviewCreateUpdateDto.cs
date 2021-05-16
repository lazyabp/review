using System;
using System.ComponentModel;
namespace Lazy.Abp.ReviewKit.Dtos
{
    [Serializable]
    public class ReviewCreateUpdateDto
    {
        [DisplayName("ReviewModuleName")]
        public string ModuleName { get; set; }

        [DisplayName("ReviewSubjectId")]
        public string SubjectId { get; set; }

        [DisplayName("ReviewParentId")]
        public Guid? ParentId { get; set; }

        [DisplayName("ReviewContent")]
        public string Content { get; set; }
    }
}