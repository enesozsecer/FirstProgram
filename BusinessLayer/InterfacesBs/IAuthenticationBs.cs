using Model.Dtos.AuthenticateDto;
using Model.Dtos.CategoryDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IAuthenticationBs
    {
        Task<List<AuthenticateGetDto>> GetAuthenticationAsync(params string[] IncludeList);
        Task<AuthenticateGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<AuthenticateGetDto>> GetRoleAsync(string name, params string[] IncludeList);
        Task<Authenticate> InsertAsync(AuthenticatePostDto entity);
        Task<Authenticate> UpdateAsync(AuthenticatePutDto entity);
        Task DeleteAsync(Guid id);
    }
}
