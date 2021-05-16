using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Lazy.Abp.ReviewKit;

namespace Lazy.Abp.ReviewKit.EntityFrameworkCore
{
    [ConnectionStringName(ReviewKitDbProperties.ConnectionStringName)]
    public interface IReviewKitDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Review> Reviews { get; set; }
        DbSet<ReviewLike> ReviewLikes { get; set; }
    }
}
