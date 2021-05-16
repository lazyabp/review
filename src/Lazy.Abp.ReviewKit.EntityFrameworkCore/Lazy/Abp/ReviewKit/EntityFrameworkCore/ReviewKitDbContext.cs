using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Lazy.Abp.ReviewKit;

namespace Lazy.Abp.ReviewKit.EntityFrameworkCore
{
    [ConnectionStringName(ReviewKitDbProperties.ConnectionStringName)]
    public class ReviewKitDbContext : AbpDbContext<ReviewKitDbContext>, IReviewKitDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewLike> ReviewLikes { get; set; }

        public ReviewKitDbContext(DbContextOptions<ReviewKitDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureReviewKit();
        }
    }
}
