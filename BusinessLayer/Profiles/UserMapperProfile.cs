using AutoMapper;
using Model.Dtos.RequestDto;
using Model.Dtos.UserDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class UserMapperProfile:Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserGetDto>();
                //.ForMember(dst => dst.CompanyName, X => X.MapFrom(src => ));
            //.ForMember(dst => dst.CategoryName, X => X.MapFrom(src => src.Category.Name))
            //.ForMember(dst => dst.UserName, X => X.MapFrom(src => src.User.Name))
            //.ForMember(dst => dst.StatusName, X => X.MapFrom(src => src.Status.Name));
            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
            CreateMap<User, UserPutDto>();
        }
    }
}
