using Model.Dtos.CategoryDto;
using Model.Dtos.UserDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface ICategoryBs
    {
        Task<List<CategoryGetDto>> GetCategoriesAsync(params string[] IncludeList);
        Task<CategoryGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<CategoryGetDto>> GetNameAsync(string name, params string[] IncludeList);
        Task<Category> InsertAsync(CategoryPostDto entity);
        Task<Category> UpdateAsync(CategoryPutDto entity);
        Task DeleteAsync(Guid id);
    }
}
