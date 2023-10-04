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
        public async Task DeleteAsync(int id)
        {
            var product = await _repo.FindByIdAsync(id);
            await _repo.DeleteAsync(product);
        }

        public async Task<Product> FindByIdAsync(int productId, params string[] IncludeList)
        {
            var product = await _repo.FindByIdAsync(productId, IncludeList);
            if (product != null)
            {
                var dto = _mapper.Map<Product>(product);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsAsync(params string[] IncludeList)
        {
            var products = await _repo.GetAllAsync(includeList: IncludeList);
            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<Product>>(products);
                return productList;
            }
            throw new NotImplementedException();
        }

        public async Task<Product> InsertAsync(Product entity)
        {
            var product = _mapper.Map<Product>(entity);
            var insertedProduct = await _repo.InsertAsync(product);
            return insertedProduct;
        }

        public async Task<List<Product>> ListByProductPriceAsync(decimal min, decimal max, params string[] IncludeList)
        {
            var products = await _repo.ListByProductPriceAsync(min, max, IncludeList);
            if (products.Count > 0)
            {
                var productList=_mapper.Map<List<Product>>(products);
                return productList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Product>> ListProductStockAsync(short min, short max, params string[] IncludeList)
        {
            var products = await _repo.ListProductStockAsync(min, max, IncludeList);
            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<Product>>(products);
                return productList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Product>> SearchProductNameAsync(string name, params string[] IncludeList)
        {
            var products = await _repo.SearchProductNameAsync(name, IncludeList);
            if (products.Count > 0)
            {
                var productList = _mapper.Map<List<Product>>(products);
                return productList;
            }
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            var product = _mapper.Map<Product>(entity);
            var updatedProduct = await _repo.UpdateAsync(product);
            return updatedProduct;
        }
    }
}
