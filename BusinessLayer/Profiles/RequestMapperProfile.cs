using AutoMapper;
using Model.Dtos.RequestDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class RequestMapperProfile : Profile
    {
        public RequestMapperProfile()
        {
            CreateMap<Request, RequestGetDto>();
            //    .ForMember(dst => dst.ProductName, X => X.MapFrom(src => src.Product.ProductName))
            //    .ForMember(dst => dst.UserName, X => X.MapFrom(src => src.User.UserName));
        }
    }
}
