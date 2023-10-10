using Model.Dtos.DepartmentDto;
using Model.Dtos.OfferDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IOfferBs
    {
        Task<List<OfferGetDto>> GetOffersAsync(params string[] IncludeList);
        Task<OfferGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<OfferGetDto>> GetNameAsync(string name, params string[] IncludeList);
        Task<Offer> InsertAsync(OfferPostDto entity);
        Task<Offer> UpdateAsync(OfferPutDto entity);
        Task DeleteAsync(Guid id);
    }
}
