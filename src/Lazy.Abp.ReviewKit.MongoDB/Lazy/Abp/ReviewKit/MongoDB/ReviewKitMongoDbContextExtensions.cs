using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.ReviewKit.MongoDB
{
    public static class ReviewKitMongoDbContextExtensions
    {
        public static void ConfigureReviewKit(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ReviewKitMongoModelBuilderConfigurationOptions(
                ReviewKitDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}