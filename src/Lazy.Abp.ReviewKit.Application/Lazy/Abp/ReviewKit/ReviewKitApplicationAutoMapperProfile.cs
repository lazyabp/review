using Lazy.Abp.ReviewKit;
using Lazy.Abp.ReviewKit.Dtos;
using AutoMapper;

namespace Lazy.Abp.ReviewKit
{
    public class ReviewKitApplicationAutoMapperProfile : Profile
    {
        public ReviewKitApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Review, ReviewDto>();
            CreateMap<Review, ReviewViewDto>()
                .ForMember(x => x.Childrens, op => op.Ignore());
        }
    }
}
