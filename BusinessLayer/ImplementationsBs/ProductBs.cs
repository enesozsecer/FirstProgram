using AutoMapper;
using BusinessLayer.InterfacesBs;
using Core.Utilities;
using DataAccessLayer.Interfaces;
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

        public async Task<Product> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<Product>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetCategoryIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetCategoryIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Product>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Product>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetPriceAsync(decimal min, decimal max, params string[] IncludeList)
        {
            var val = await _repo.GetPriceAsync(min,max, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Product>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetStockAsync(short min, short max, params string[] IncludeList)
        {
            var val = await _repo.GetStockAsync(min, max, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Product>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Product> InsertAsync(Product entity)
        {
            var product = _mapper.Map<Product>(entity);
            var insertedProduct = await _repo.InsertAsync(product);
            return insertedProduct;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var product = _mapper.Map<Product>(entity);
            var updatedProduct = await _repo.UpdateAsync(product);
            return updatedProduct;
        }
    }
}
