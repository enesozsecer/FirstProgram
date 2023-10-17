using Core.Utilities.Response;
using Model.Dtos.UserLoginDto;
using Model.Entities;

namespace FirstProgramUI.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<ApiDataResponse<User>> LoginAsync(LoginDto loginDto);
    }
}
