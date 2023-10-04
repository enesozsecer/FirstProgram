using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> SearchProductNameAsync(string name, params string[] IncludeList);
        Task<List<Product>> ListByProductPriceAsync(decimal min, decimal max, params string[] IncludeList);
        Task<List<Product>> ListProductStockAsync(short min, short max, params string[] IncludeList);
        Task<Product> FindByIdAsync(int productId, params string[] IncludeList);
    }
}
