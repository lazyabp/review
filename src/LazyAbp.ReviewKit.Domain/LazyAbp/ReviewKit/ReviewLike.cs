using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace LazyAbp.ReviewKit
{
    public class ReviewLike : Entity<Guid>
    {
        public Guid ReviewId { get; private set; }

        public Guid UserId { get; private set; }

        public bool IsLike { get; private set; }

        protected ReviewLike()
        {
        }

        public ReviewLike(
            Guid id, 
            Guid reviewId, 
            Guid userId, 
            bool isLike
        ) : base(id)
        {
            ReviewId = reviewId;
            UserId = userId;
            IsLike = isLike;
        }

        public void SetLike(bool isLike)
        {
            IsLike = isLike;
        }
    }
}
