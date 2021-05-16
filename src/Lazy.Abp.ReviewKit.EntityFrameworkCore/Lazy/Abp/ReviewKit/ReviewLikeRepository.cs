using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lazy.Abp.ReviewKit.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.ReviewKit
{
    public class ReviewLikeRepository : EfCoreRepository<IReviewKitDbContext, ReviewLike, Guid>, IReviewLikeRepository
    {
        public ReviewLikeRepository(IDbContextProvider<IReviewKitDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<ReviewLike> GetUserReviewLikeAsync(Guid userId, Guid reviewId, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking()
                    .Where(q => q.UserId == userId && q.ReviewId == reviewId)
                    .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}