using Model.Dtos.UserLoginDto;
using Model.Entities;

namespace FirstProgramUI.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<User> LoginAsync(LoginDto loginDto);
    }
}
