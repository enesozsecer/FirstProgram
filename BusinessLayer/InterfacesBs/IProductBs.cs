using Core.Utilities;
using Model.Dtos.ProductDto;
using Model.Dtos.UserDto;
using Model.Entities;

namespace BusinessLayer.InterfacesBs
{
    public interface IProductBs
    {
        Task<List<ProductGetDto>> GetProductsAsync(params string[] IncludeList);
        Task<ProductGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<ProductGetDto>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<ProductGetDto>> GetStockAsync(short min, short max, params string[] IncludeList);
        Task<List<ProductGetDto>> GetPriceAsync(decimal min, decimal max, params string[] IncludeList);
        Task<List<ProductGetDto>> GetCategoryIdAsync(Guid Id, params string[] IncludeList);
        Task<List<ProductGetDto>> GetInvoiceIdAsync(Guid Id, params string[] IncludeList);
        Task<Product> InsertAsync(ProductPostDto entity);
        Task<Product> UpdateAsync(ProductPutDto entity);
        Task DeleteAsync(Guid id);
    }
}
