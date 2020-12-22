using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using LazyAbp.ReviewKit.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace LazyAbp.ReviewKit
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
                    .AddVirtualJson("/LazyAbp/ReviewKit/Localization");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ReviewKit", typeof(ReviewKitResource));
            });
        }
    }
}
