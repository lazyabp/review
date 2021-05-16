using AutoMapper;
using Lazy.Abp.ReviewKit.Dtos;
using System;

namespace Lazy.Abp.ReviewKit.Admin
{
    public class ReviewKitAdminApplicationAutoMapperProfile : Profile
    {
        public ReviewKitAdminApplicationAutoMapperProfile()
        {
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewCreateUpdateDto, Review>(MemberList.Source);
        }
    }
}
