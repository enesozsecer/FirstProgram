using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;

namespace DataAccessLayer.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, FirstProgramContext>, IProductRepository
    {
        public async Task<Product> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Product>> GetCategoryIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.CategoryID==Id, IncludeList);
        }
        public async Task<List<Product>> GetInvoiceIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.InvoiceID == Id, IncludeList);
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
