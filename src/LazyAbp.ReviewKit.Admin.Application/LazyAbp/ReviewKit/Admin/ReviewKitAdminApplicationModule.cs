using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit.Admin
{
    [DependsOn(
        typeof(ReviewKitDomainModule),
        typeof(ReviewKitAdminApplicationContractsModule),
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule))]
    public class ReviewKitAdminApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<ReviewKitAdminApplicationModule>();
            
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ReviewKitAdminApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
