using Model.Entities;

namespace FirstProgramUI.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<List<User>> GetListAsync();
    }
}
