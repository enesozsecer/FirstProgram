using Core.Helpers;
using Model.Dtos.UserLoginDto;
using Model.Entities;

namespace BusinessLayer.InterfacesBs
{
    public interface IUserBs
    {
        Task<User> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<User>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<User>> GetRoleNameAsync(string roleName, params string[] IncludeList);
        Task<List<User>> GetDepartmentNameAsync(string departmentName, params string[] IncludeList);
        Task<List<User>> GetCompanyNameAsync(string companyName, params string[] IncludeList);
        Task<User> InsertAsync(User entity);
        Task<User> UpdateAsync(User entity);
        Task DeleteAsync(int id);
    }
}
