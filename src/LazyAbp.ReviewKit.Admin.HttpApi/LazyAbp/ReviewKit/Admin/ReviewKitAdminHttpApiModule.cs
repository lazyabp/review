using LazyAbp.ReviewKit.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit.Admin
{
    [DependsOn(
        typeof(ReviewKitAdminApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class ReviewKitAdminHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(ReviewKitAdminHttpApiModule).Assembly);
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
