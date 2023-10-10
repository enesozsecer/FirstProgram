using AutoMapper;
using Model.Dtos.ProductDto;
using Model.Dtos.RequestDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductGetDto>();
            //.ForMember(dst => dst.CategoryName, X => X.MapFrom(src => src.Category.Name))
            //.ForMember(dst => dst.UserName, X => X.MapFrom(src => src.User.Name))
            //.ForMember(dst => dst.StatusName, X => X.MapFrom(src => src.Status.Name));
            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();
        }
    }
}
