using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.ReviewKit
{
    [DependsOn(
        typeof(ReviewKitApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ReviewKitHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "ReviewKit";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ReviewKitApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
