using Core.Utilities;
using Model.Entities;

namespace BusinessLayer.InterfacesBs
{
    public interface IProductBs
    {
        Task<Product> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Product>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<Product>> GetStockAsync(short min, short max, params string[] IncludeList);
        Task<List<Product>> GetPriceAsync(decimal min, decimal max, params string[] IncludeList);
        Task<List<Product>> GetCategoryIdAsync(Guid Id, params string[] IncludeList);
        Task<Product> InsertAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task DeleteAsync(Guid id);
    }
}
