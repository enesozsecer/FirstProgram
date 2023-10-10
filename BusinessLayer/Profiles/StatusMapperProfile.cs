using AutoMapper;
using Model.Dtos.RequestDto;
using Model.Dtos.StatusDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class StatusMapperProfile : Profile
    {
        public StatusMapperProfile()
        {
            CreateMap<Status, StatusGetDto>();
                //.ForMember(dst => dst.CategoryName, X => X.MapFrom(src => src.Category.Name))
                //.ForMember(dst => dst.UserName, X => X.MapFrom(src => src.User.Name))
                //.ForMember(dst => dst.StatusName, X => X.MapFrom(src => src.Status.Name));
            CreateMap<StatusPostDto, Status>();
            CreateMap<StatusPutDto, Status>();
        }
    }
}
