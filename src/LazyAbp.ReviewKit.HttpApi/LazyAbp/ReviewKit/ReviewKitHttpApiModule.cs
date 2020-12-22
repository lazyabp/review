using Localization.Resources.AbpUi;
using LazyAbp.ReviewKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace LazyAbp.ReviewKit
{
    [DependsOn(
        typeof(ReviewKitApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ReviewKitHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ReviewKitHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ReviewKitResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
