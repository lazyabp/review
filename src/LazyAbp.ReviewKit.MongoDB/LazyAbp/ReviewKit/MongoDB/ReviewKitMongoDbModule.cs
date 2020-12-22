using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace LazyAbp.ReviewKit.MongoDB
{
    [DependsOn(
        typeof(ReviewKitDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class ReviewKitMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<ReviewKitMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
