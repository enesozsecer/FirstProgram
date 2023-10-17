using Core.Utilities.Response;
using Model.Dtos.UserDto;
using Model.Entities;
using System.Linq.Expressions;

namespace BusinessLayer.InterfacesBs
{
    public interface IUserBs
    {
        Task<List<UserGetDto>> GetUsersAsync(params string[] IncludeList);
        Task<UserGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<ApiDataResponse<UserGetDto>> GetAsync(Expression<Func<User, bool>> predicate, params string[] includeList);
        Task<List<UserGetDto>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<UserGetDto>> GetRoleIdAsync(Guid Id, params string[] IncludeList);
        Task<List<UserGetDto>> GetDepartmentIdAsync(Guid Id, params string[] IncludeList);
        Task<List<UserGetDto>> GetCompanyIdAsync(Guid Id, params string[] IncludeList);
        Task<User> InsertAsync(UserPostDto entity);
        Task<User> UpdateAsync(UserPutDto entity);
        Task DeleteAsync(Guid id);
    }
}
