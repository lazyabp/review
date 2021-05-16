using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Lazy.Abp.ReviewKit
{
    public interface IReviewLikeRepository : IRepository<ReviewLike, Guid>
    {
        Task<ReviewLike> GetUserReviewLikeAsync(Guid userId, Guid reviewId, CancellationToken cancellationToken = default);
    }
}