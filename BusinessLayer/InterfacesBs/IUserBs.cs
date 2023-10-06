using Core.Helpers;
using Model.Dtos.UserLoginDto;
using Model.Entities;

namespace BusinessLayer.InterfacesBs
{
    public interface IUserBs
    {
        Task<User> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<User>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<User>> GetRoleIdAsync(Guid Id, params string[] IncludeList);
        Task<List<User>> GetDepartmentIdAsync(Guid Id, params string[] IncludeList);
        Task<List<User>> GetCompanyIdAsync(Guid Id, params string[] IncludeList);
        Task<User> InsertAsync(User entity);
        Task<User> UpdateAsync(User entity);
        Task DeleteAsync(Guid id);
    }
}
