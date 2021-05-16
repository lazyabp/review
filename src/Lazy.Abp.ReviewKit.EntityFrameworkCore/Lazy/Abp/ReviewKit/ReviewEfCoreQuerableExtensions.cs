using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lazy.Abp.ReviewKit
{
    public static class ReviewEfCoreQueryableExtensions
    {
        public static IQueryable<Review> IncludeDetails(this IQueryable<Review> queryable, bool include = true)
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