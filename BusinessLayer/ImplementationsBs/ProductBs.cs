using AutoMapper;
using BusinessLayer.InterfacesBs;
using Core.Utilities;
using DataAccessLayer.Interfaces;
using Model.Dtos.ProductDto;
using Model.Dtos.RequestDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class ProductBs : IProductBs
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductBs(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            var product = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(product);
        }

        public async Task<ProductGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<ProductGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<ProductGetDto>> GetCategoryIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetCategoryIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<ProductGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<ProductGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<ProductGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<ProductGetDto>> GetPriceAsync(decimal min, decimal max, params string[] IncludeList)
        {
            var val = await _repo.GetPriceAsync(min,max, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<ProductGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<ProductGetDto>> GetProductsAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<ProductGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<List<ProductGetDto>> GetStockAsync(short min, short max, params string[] IncludeList)
        {
            var val = await _repo.GetStockAsync(min, max, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<ProductGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Product> InsertAsync(ProductPostDto entity)
        {
            var val = _mapper.Map<Product>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Product> UpdateAsync(ProductPutDto entity)
        {
            var val = _mapper.Map<Product>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
