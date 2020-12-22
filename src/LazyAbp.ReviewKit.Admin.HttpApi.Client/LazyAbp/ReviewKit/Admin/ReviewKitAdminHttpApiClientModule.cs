using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit.Admin
{
    [DependsOn(
        typeof(ReviewKitAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ReviewKitAdminHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(ReviewKitAdminApplicationContractsModule).Assembly,
                ReviewKitAdminRemoteServiceConsts.RemoteServiceName);
        }
    }
}
