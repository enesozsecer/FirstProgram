using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;

namespace DataAccessLayer.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, FirstProgramContext>, IProductRepository
    {
        public async Task<Product> GetByIdAsync(int Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Product>> GetCategoryNameAsync(string CategoryName, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.CategoryName.Contains(CategoryName), IncludeList);
        }

        public async Task<List<Product>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }

        public async Task<List<Product>> GetPriceAsync(decimal min, decimal max, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.ProductPrice < max && val.ProductPrice > min, IncludeList);
        }

        public async Task<List<Product>> GetStockAsync(short min, short max, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.StockQuantity < max && val.StockQuantity > min, IncludeList);
        }
    }
}
