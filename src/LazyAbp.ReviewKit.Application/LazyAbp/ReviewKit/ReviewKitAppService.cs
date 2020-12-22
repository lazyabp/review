using LazyAbp.ReviewKit.Localization;
using Volo.Abp.Application.Services;

namespace LazyAbp.ReviewKit
{
    public abstract class ReviewKitAppService : ApplicationService
    {
        protected ReviewKitAppService()
        {
            LocalizationResource = typeof(ReviewKitResource);
            ObjectMapperContext = typeof(ReviewKitApplicationModule);
        }
    }
}
