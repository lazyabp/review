using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LazyAbp.ReviewKit
{
    public static class ReviewLikeEfCoreQueryableExtensions
    {
        public static IQueryable<ReviewLike> IncludeDetails(this IQueryable<ReviewLike> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}