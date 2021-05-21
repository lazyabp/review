using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Lazy.Abp.ReviewKit.Admin
{
    [DependsOn(
        typeof(ReviewKitApplicationContractsModule),
        typeof(ReviewKitDomainSharedModule)
        )]
    public class ReviewKitAdminApplicationContractsModule : AbpModule
    {
    }
}
