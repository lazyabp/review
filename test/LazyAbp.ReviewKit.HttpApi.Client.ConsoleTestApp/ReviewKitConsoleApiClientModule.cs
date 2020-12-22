using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit
{
    [DependsOn(
        typeof(ReviewKitHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ReviewKitConsoleApiClientModule : AbpModule
    {
        
    }
}
