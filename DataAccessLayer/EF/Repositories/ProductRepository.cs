using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;

namespace DataAccessLayer.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, FirstProgramContext>, IProductRepository
    {
        public async Task<Product> FindByIdAsync(int productId, params string[] IncludeList)
        {
            return await FindAsync(prd => prd.ProductID == productId, IncludeList);
        }

        public async Task<List<Product>> ListByProductPriceAsync(decimal min, decimal max, params string[] IncludeList)
        {
            return await GetAllAsync(prd => prd.ProductPrice < max && prd.ProductPrice > min, IncludeList);
        }

        public async Task<List<Product>> ListProductStockAsync(short min, short max, params string[] IncludeList)
        {
            return await GetAllAsync(prd => prd.StockQuantity < max && prd.StockQuantity > min, IncludeList);
        }

        public async Task<List<Product>> SearchProductNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(prd => prd.ProductName.Contains(name), IncludeList);
        }
    }
}
