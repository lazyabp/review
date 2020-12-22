using LazyAbp.ReviewKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace LazyAbp.ReviewKit.Admin
{
    public abstract class ReviewKitAdminAppServiceBase : ApplicationService
    {
        protected ReviewKitAdminAppServiceBase()
        {
            ObjectMapperContext = typeof(ReviewKitAdminApplicationModule);
            LocalizationResource = typeof(ReviewKitResource);
        }
    }
}
