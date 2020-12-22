using AutoMapper;
using LazyAbp.ReviewKit.Dtos;
using System;

namespace LazyAbp.ReviewKit.Admin
{
    public class ReviewKitAdminApplicationAutoMapperProfile : Profile
    {
        public ReviewKitAdminApplicationAutoMapperProfile()
        {
            CreateMap<CreateUpdateReviewDto, Review>(MemberList.Source);
        }
    }
}
