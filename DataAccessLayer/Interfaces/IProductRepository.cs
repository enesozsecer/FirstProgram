using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IProductRepository : BaseRepository<Product>
    {
        Task<Product> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Product>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<Product>> GetStockAsync(short min, short max, params string[] IncludeList);
        Task<List<Product>> GetPriceAsync(decimal min, decimal max, params string[] IncludeList);
        Task<List<Product>> GetCategoryIdAsync(Guid Id, params string[] IncludeList);
    }
}
