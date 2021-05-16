using Lazy.Abp.ReviewKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.ReviewKit
{
    public abstract class ReviewKitController : AbpController
    {
        protected ReviewKitController()
        {
            LocalizationResource = typeof(ReviewKitResource);
        }
    }
}
