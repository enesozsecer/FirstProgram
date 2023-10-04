using Core.Helpers;
using Model.Dtos.UserLoginDto;
using Model.Entities;

namespace BusinessLayer.InterfacesBs
{
    public interface IUserBs
    {
        Task<List<User>> FindUserRoleAsync(string role, params string[] IncludeList);
        Task<User> FindByIdAsync(int userId, params string[] IncludeList);
        Task<User> InsertAsync(User entity);
        Task<User> UpdateAsync(User entity);
        Task DeleteAsync(int id);
        Task<AccessToken> AuthenticateAsync(LoginDto dto);
    }
}
