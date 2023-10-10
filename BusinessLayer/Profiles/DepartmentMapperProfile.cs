using AutoMapper;
using Model.Dtos.DepartmentDto;
using Model.Dtos.RequestDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class DepartmentMapperProfile : Profile
    {
        public DepartmentMapperProfile()
        {
            CreateMap<Department, DepartmentGetDto>();
            //.ForMember(dst => dst.CategoryName, X => X.MapFrom(src => src.Category.Name))
            //.ForMember(dst => dst.UserName, X => X.MapFrom(src => src.User.Name))
            //.ForMember(dst => dst.StatusName, X => X.MapFrom(src => src.Status.Name));
            CreateMap<DepartmentPostDto, Department>();
            CreateMap<DepartmentPutDto, Department>();
        }
    }
}
