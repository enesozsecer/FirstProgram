using Model.Dtos.CategoryDto;
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
        Task<Category> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Category>> GetNameAsync(string name, params string[] IncludeList);
        Task<Category> InsertAsync(CategoryPostDto entity);
        Task<Category> UpdateAsync(CategoryPutDto entity);
        Task DeleteAsync(Guid id);
    }
}
