using System;
using System.ComponentModel;
namespace LazyAbp.ReviewKit.Dtos
{
    [Serializable]
    public class CreateUpdateReviewDto
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