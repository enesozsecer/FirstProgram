using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<List<OfferGetDto>> GetAsyncByProduct(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetAsyncByProduct(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<OfferGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<OfferGetDto>> GetAsyncByStatus(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetAsyncByStatus(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<OfferGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
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
            entity.StatusID = Guid.Parse("34f0086e-304e-4eb4-99a1-1c54343a9d7c");
            entity.OfferPrice = decimal.Parse("0");
            var val = _mapper.Map<Offer>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Offer> UpdateAsync(OfferPutDto entity)
        {
            if (entity.InvoiceID != null)
                entity.StatusID = Guid.Parse("34f0086e-304e-4eb4-99a1-1c54343a9d7c");
            var val = _mapper.Map<Offer>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }

        /// <summary>
        /// Hepsini Birden Günceller!!!!
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<List<Offer>> UpdateAllAsync(OfferPutDto entity)
        {
            var updateofferList = await _repo.GetAllAsync(e=>e.ProductID==entity.ProductID);
            var val1 = _mapper.Map<Offer>(entity);
            var updateVal=  await _repo.UpdateAsync(val1);

            foreach (var val in updateofferList)
            {
                if (val.InvoiceID != null)
                {
                    val.StatusID = Guid.Parse("cc101694-ca18-4f96-9d01-b60892276608");
                    var val2 = _mapper.Map<Offer>(val);
                    await _repo.UpdateAsync(val2);
                }
                else
                {
                    val.StatusID = Guid.Parse("fa7bd65b-b71c-4490-b78e-f2d0314ee719");
                    var val2 = _mapper.Map<Offer>(val);
                    await _repo.UpdateAsync(val2);
                }
            }
            return updateofferList;
        }
    }
}
