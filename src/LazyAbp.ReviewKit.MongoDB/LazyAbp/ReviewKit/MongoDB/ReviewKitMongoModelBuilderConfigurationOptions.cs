using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace LazyAbp.ReviewKit.MongoDB
{
    public class ReviewKitMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public ReviewKitMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}