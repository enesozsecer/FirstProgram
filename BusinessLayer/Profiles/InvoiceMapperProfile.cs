using AutoMapper;
using Model.Dtos.CategoryDto;
using Model.Dtos.InvoiceDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class InvoiceMapperProfile:Profile
    {
        public InvoiceMapperProfile()
        {
            CreateMap<Invoice, InvoiceGetDto>();
            CreateMap<InvoicePostDto, Invoice>();
            CreateMap<InvoicePutDto, Invoice>();
        }
    }
}
