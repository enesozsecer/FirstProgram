using AutoMapper;
using Model.Dtos.RoleDto;
using Model.Dtos.CategoryDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<Role, RoleGetDto>();
            CreateMap<RolePostDto, Role>();
            CreateMap<RolePutDto, Role>();
        }

    }
}
