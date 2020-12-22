using LazyAbp.ReviewKit.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ReviewKitEntityFrameworkCoreTestModule)
        )]
    public class ReviewKitDomainTestModule : AbpModule
    {
        
    }
}
