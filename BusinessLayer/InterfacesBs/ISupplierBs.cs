using Model.Dtos.RequestDto;
using Model.Dtos.SupplierDto;
using Model.Dtos.UserDto;
using Model.Entities;

namespace BusinessLayer.InterfacesBs;

public interface ISupplierBs
{
    Task<List<SupplierGetDto>> GetSuppliersAsync(params string[] IncludeList);
    Task<SupplierGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
    Task<List<SupplierGetDto>> GetNameAsync(string name, params string[] IncludeList);
    Task<List<SupplierGetDto>> GetCategoryIdAsync(Guid Id, params string[] IncludeList);
    Task<Supplier> InsertAsync(SupplierPostDto entity);
    Task<Supplier> UpdateAsync(SupplierPutDto entity);
    Task DeleteAsync(Guid id);
}
