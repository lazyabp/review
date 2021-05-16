using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.ReviewKit.EntityFrameworkCore
{
    public class ReviewKitModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ReviewKitModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}