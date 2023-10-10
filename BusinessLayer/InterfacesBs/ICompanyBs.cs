using Model.Dtos.CategoryDto;
using Model.Dtos.CompanyDto;
using Model.Dtos.UserDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface ICompanyBs
    {
        Task<List<CompanyGetDto>> GetCompaniesAsync(params string[] IncludeList);
        Task<CompanyGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<CompanyGetDto>> GetNameAsync(string name, params string[] IncludeList);
        Task<Company> InsertAsync(CompanyPostDto entity);
        Task<Company> UpdateAsync(CompanyPutDto entity);
        Task DeleteAsync(Guid id);
    }
}
