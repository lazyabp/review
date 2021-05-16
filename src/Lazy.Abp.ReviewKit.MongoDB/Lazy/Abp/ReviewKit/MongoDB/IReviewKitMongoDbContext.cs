using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.ReviewKit.MongoDB
{
    [ConnectionStringName(ReviewKitDbProperties.ConnectionStringName)]
    public interface IReviewKitMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
