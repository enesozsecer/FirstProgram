using AutoMapper;
using Model.Dtos.CategoryDto;
using Model.Dtos.SupplierDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class SupplierMapperProfile:Profile
    {
        public SupplierMapperProfile()
        {
            CreateMap<Supplier, SupplierGetDto>();
            CreateMap<SupplierPutDto, Supplier>();
            CreateMap<SupplierPostDto, Supplier>();
        }
    }
}
