using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Lazy.Abp.ReviewKit.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Lazy.Abp.ReviewKit
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class ReviewKitDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ReviewKitDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ReviewKitResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Lazy/Abp/ReviewKit/Localization/ReviewKit");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ReviewKit", typeof(ReviewKitResource));
            });
        }
    }
}
