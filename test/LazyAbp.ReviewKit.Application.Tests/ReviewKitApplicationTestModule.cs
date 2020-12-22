using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit
{
    [DependsOn(
        typeof(ReviewKitApplicationModule),
        typeof(ReviewKitDomainTestModule)
        )]
    public class ReviewKitApplicationTestModule : AbpModule
    {

    }
}
