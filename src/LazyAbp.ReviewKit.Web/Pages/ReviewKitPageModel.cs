﻿using LazyAbp.ReviewKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace LazyAbp.ReviewKit.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ReviewKitPageModel : AbpPageModel
    {
        protected ReviewKitPageModel()
        {
            LocalizationResourceType = typeof(ReviewKitResource);
            ObjectMapperContext = typeof(ReviewKitWebModule);
        }
    }
}