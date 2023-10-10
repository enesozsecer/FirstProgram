using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.DepartmentDto;
using Model.Dtos.OfferDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class OfferBs : IOfferBs
    {
        private readonly IOfferRepository _repo;
        private readonly IMapper _mapper;
        public OfferBs(IOfferRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<OfferGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<OfferGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<OfferGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<OfferGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<OfferGetDto>> GetOffersAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<OfferGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<Offer> InsertAsync(OfferPostDto entity)
        {
            var val = _mapper.Map<Offer>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Offer> UpdateAsync(OfferPutDto entity)
        {
            var val = _mapper.Map<Offer>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
