using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Lazy.Abp.ReviewKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.ReviewKit
{
    public class ReviewRepository : EfCoreRepository<IReviewKitDbContext, Review, Guid>, IReviewRepository
    {
        public ReviewRepository(IDbContextProvider<IReviewKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Review>> GetByRootAsync(List<Guid> rootIds, AuditStatus? status = null, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking()
                    .Where(q => rootIds.Contains(q.RootId.Value))
                    .WhereIf(status.HasValue,
                        e => false
                        || e.Status == status
                    )
                    .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(
            Guid? userId = null,
            string moduleName = null,
            string subjectId = null,
            Guid? parentId = null,
            Guid? rootId = null,
            AuditStatus? status = null,
            string filter = null,
            bool filterParent = false,
            CancellationToken cancellationToken = default
            )
        {
            var query = GetListQuery(userId, moduleName, subjectId, parentId, rootId, status, filter, filterParent);

            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Review>> GetListAsync(
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
            )
        {
            var query = GetListQuery(userId, moduleName, subjectId, parentId, rootId, status, filter, filterParent);

            var list = await query.OrderBy(sorting ?? "creationTime desc")
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            return list;
        }

        protected IQueryable<Review> GetListQuery(
            Guid? userId = null,
            string moduleName = null,
            string subjectId = null,
            Guid? parentId = null,
            Guid? rootId = null,
            AuditStatus? status = null,
            string filter = null,
            bool filterParent = false
            )
        {
            return DbSet
                .WhereIf(userId.HasValue, e => e.UserId == userId)
                .WhereIf(!moduleName.IsNullOrEmpty(), e => e.ModuleName == moduleName)
                .WhereIf(!subjectId.IsNullOrEmpty(), e => e.SubjectId == subjectId)
                .WhereIf(!filterParent && parentId.HasValue, e => e.ParentId == parentId)
                .WhereIf(filterParent, e => !e.ParentId.HasValue)
                .WhereIf(rootId.HasValue, e => e.RootId == rootId)
                .WhereIf(status.HasValue, e => e.Status == status)
                .WhereIf(!string.IsNullOrEmpty(filter),
                    e => false
                    || e.Content.Contains(filter)
                    || e.AuditRemark.Contains(filter)
                );
        }
    }
}