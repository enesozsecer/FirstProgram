using AutoMapper;
using Model.Dtos.AuthenticateDto;
using Model.Dtos.CategoryDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class AuthenticationMapperProfile : Profile
    {
        public AuthenticationMapperProfile()
        {
            CreateMap<Authenticate, AuthenticateGetDto>();
            CreateMap<AuthenticatePostDto, Authenticate>();
            CreateMap<AuthenticatePutDto, Authenticate>();
        }

    }
}
