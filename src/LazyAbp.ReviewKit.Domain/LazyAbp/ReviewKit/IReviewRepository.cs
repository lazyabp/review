using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using System.Threading;

namespace LazyAbp.ReviewKit
{
    public interface IReviewRepository : IRepository<Review, Guid>
    {
        Task<List<Review>> GetByRootAsync(List<Guid> rootIds, AuditStatus? status = null, CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            Guid? userId = null,
            string moduleName = null,
            string subjectId = null,
            Guid? parentId = null,
            Guid? rootId = null,
            AuditStatus? status = null,
            string filter = null,
            bool filterParent = false,
            CancellationToken cancellationToken = default
            );

        Task<List<Review>> GetListAsync(
            Guid? userId = null,
            string moduleName = null,
            string subjectId = null,
            Guid? parentId = null,
            Guid? rootId = null,
            AuditStatus? status = null,
            string filter = null,
            bool filterParent = false,
            int maxResultCount = 10,
            int skipCount = 0,
            string sorting = null,
            CancellationToken cancellationToken = default
            );
    }
}