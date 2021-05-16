using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Lazy.Abp.ReviewKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(ReviewKitDomainSharedModule)
    )]
    public class ReviewKitDomainModule : AbpModule
    {

    }
}
