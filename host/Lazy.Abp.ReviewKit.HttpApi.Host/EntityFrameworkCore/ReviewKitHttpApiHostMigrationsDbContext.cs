using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.ReviewKit.EntityFrameworkCore
{
    public class ReviewKitHttpApiHostMigrationsDbContext : AbpDbContext<ReviewKitHttpApiHostMigrationsDbContext>
    {
        public ReviewKitHttpApiHostMigrationsDbContext(DbContextOptions<ReviewKitHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureReviewKit();
        }
    }
}
