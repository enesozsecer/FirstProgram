using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IAuthenticateRepository : BaseRepository<Authenticate>
    {
        Task<Authenticate> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Authenticate>> GetNameAsync(string name, params string[] IncludeList);
    }
}
