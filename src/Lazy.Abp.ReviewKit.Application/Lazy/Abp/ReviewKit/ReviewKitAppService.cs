using Lazy.Abp.ReviewKit.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.ReviewKit
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
