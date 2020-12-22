﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace LazyAbp.ReviewKit
{
    [DependsOn(
        typeof(ReviewKitDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class ReviewKitApplicationContractsModule : AbpModule
    {

    }
}
