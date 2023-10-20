using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.ProductDto;
using Model.Dtos.RequestDto;
using Model.Dtos.RoleDto;
using Model.Dtos.SupplierDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{

    public class SupplierBs : ISupplierBs
    {
        private readonly ISupplierRepository _repo;
        private readonly IMapper _mapper;
        public SupplierBs(ISupplierRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<SupplierGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<SupplierGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<SupplierGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<SupplierGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<SupplierGetDto>> GetSuppliersAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<SupplierGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }
        public async Task<List<SupplierGetDto>> GetCategoryIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetCategoryIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<SupplierGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Supplier> InsertAsync(SupplierPostDto entity)
        {
            var val = _mapper.Map<Supplier>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Supplier> UpdateAsync(SupplierPutDto entity)
        {
            var val = _mapper.Map<Supplier>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
