using AutoMapper;
using Model.Dtos.CategoryDto;
using Model.Dtos.RequestDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class CategoryMapperProfile:Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<CategoryPostDto, Category>();
        }
    }
}
