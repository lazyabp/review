using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace LazyAbp.ReviewKit
{
    public class Review : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        /// <summary>
        /// 评论人
        /// </summary>
        public Guid? UserId { get; private set; }

        /// <summary>
        /// 评论所在模块
        /// </summary>
        [NotNull]
        [MaxLength(ReviewConsts.MaxModuleNameLength)]
        public string ModuleName { get; private set; }

        /// <summary>
        /// 评论的主题的ID
        /// </summary>
        [NotNull]
        [MaxLength(ReviewConsts.MaxModuleIdLength)]
        public string SubjectId { get; private set; }

        /// <summary>
        /// 评论的上级ID
        /// </summary>
        public Guid? ParentId { get; private set; }

        /// <summary>
        /// 评论的顶级ID
        /// </summary>
        public Guid? RootId { get; private set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        [NotNull]
        public string Content { get; private set; }

        public int LikeCount { get; private set; }

        /// <summary>
        /// 评论人IP地址
        /// </summary>
        public string IpAddress { get; private set; }

        /// <summary>
        /// 评论人浏览器信息
        /// </summary>
        public string UserAgent { get; private set; }

        /// <summary>
        /// 评论状态
        /// </summary>
        public AuditStatus Status { get; private set; }

        /// <summary>
        /// 审核备注
        /// </summary>
        public string AuditRemark { get; private set; }

        protected Review()
        {
        }

        public Review(
            Guid id,
            Guid? tenantId,
            Guid? userId, 
            [NotNull] string moduleName,
            [NotNull] string subjectId,
            Guid? parentId,
            Guid? rootId,
            [NotNull] string content,
            string ipAddress, 
            string userAgent
        ) : base(id)
        {
            Check.NotNullOrEmpty(moduleName, nameof(moduleName));
            Check.NotNullOrEmpty(subjectId, nameof(subjectId));
            Check.NotNullOrEmpty(content, nameof(content));

            TenantId = tenantId;
            UserId = userId;
            ModuleName = moduleName;
            SubjectId = subjectId;
            ParentId = parentId;
            RootId = rootId;
            Content = content;
            IpAddress = ipAddress;
            UserAgent = userAgent;

            LikeCount = 0;
        }

        public void Update(string content)
        {
            Content = content;
        }

        /// <summary>
        /// 审核评论
        /// </summary>
        /// <param name="status"></param>
        /// <param name="auditRmark"></param>
        public void Audit(AuditStatus status, string auditRmark = "")
        {
            Status = status;

            if (!string.IsNullOrEmpty(auditRmark))
                AuditRemark = auditRmark;
        }

        public int ToggleLike(bool like)
        {
            if (like)
                LikeCount++;
            else
                LikeCount--;

            return LikeCount;
        }
    }
}
