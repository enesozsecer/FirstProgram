using Model.Dtos.RoleDto;
using Model.Dtos.CategoryDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IRoleBs
    {
        Task<List<RoleGetDto>> GetRoleAsync(params string[] IncludeList);
        Task<RoleGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<RoleGetDto>> GetRoleAsync(string name, params string[] IncludeList);
        Task<Role> InsertAsync(RolePostDto entity);
        Task<Role> UpdateAsync(RolePutDto entity);
        Task DeleteAsync(Guid id);
    }
}
