using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Lazy.Abp.ReviewKit
{
    [DependsOn(
        typeof(ReviewKitDomainModule),
        typeof(ReviewKitApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class ReviewKitApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ReviewKitApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<ReviewKitApplicationModule>(validate: true);
            });
        }
    }
}
