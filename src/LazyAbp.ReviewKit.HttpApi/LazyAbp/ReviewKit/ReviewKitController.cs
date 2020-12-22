using LazyAbp.ReviewKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.ReviewKit
{
    public abstract class ReviewKitController : AbpController
    {
        protected ReviewKitController()
        {
            LocalizationResource = typeof(ReviewKitResource);
        }
    }
}
