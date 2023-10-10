using Model.Dtos.DepartmentDto;
using Model.Dtos.UserDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IDepartmentBs
    {
        Task<List<DepartmentGetDto>> GetDepartmentsAsync(params string[] IncludeList);
        Task<DepartmentGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<DepartmentGetDto>> GetNameAsync(string name, params string[] IncludeList);
        Task<Department> InsertAsync(DepartmentPostDto entity);
        Task<Department> UpdateAsync(DepartmentPutDto entity);
        Task DeleteAsync(Guid id);
    }
}
