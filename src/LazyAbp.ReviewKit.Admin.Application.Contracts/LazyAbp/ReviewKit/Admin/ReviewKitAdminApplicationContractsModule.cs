using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace LazyAbp.ReviewKit.Admin
{
    [DependsOn(typeof(ReviewKitDomainSharedModule))]
    public class ReviewKitAdminApplicationContractsModule : AbpModule
    {
    }
}
