using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ReviewKitDomainSharedModule)
    )]
    public class ReviewKitDomainModule : AbpModule
    {

    }
}
