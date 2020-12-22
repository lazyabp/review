using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.ReviewKit.MongoDB
{
    [ConnectionStringName(ReviewKitDbProperties.ConnectionStringName)]
    public class ReviewKitMongoDbContext : AbpMongoDbContext, IReviewKitMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureReviewKit();
        }
    }
}