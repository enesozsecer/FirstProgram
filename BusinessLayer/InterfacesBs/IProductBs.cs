using Core.Utilities;
using Model.Entities;

namespace BusinessLayer.InterfacesBs
{
    public interface IProductBs
    {
        Task<List<Product>> GetProductsAsync(params string[] IncludeList);
        Task<List<Product>> SearchProductNameAsync(string name, params string[] IncludeList);
        Task<List<Product>> ListByProductPriceAsync(decimal min, decimal max, params string[] IncludeList);
        Task<List<Product>> ListProductStockAsync(short min, short max, params string[] IncludeList);
        Task<Product> FindByIdAsync(int productId, params string[] IncludeList);
        Task<Product> InsertAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task DeleteAsync(int id);
    }
}
