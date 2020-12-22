using LazyAbp.ReviewKit;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit.EntityFrameworkCore
{
    [DependsOn(
        typeof(ReviewKitDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class ReviewKitEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ReviewKitDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Review, ReviewRepository>();
                options.AddRepository<ReviewLike, ReviewLikeRepository>();
            });
        }
    }
}
