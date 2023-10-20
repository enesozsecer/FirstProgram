using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IRoleRepository : BaseRepository<Role>
    {
        Task<Role> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Role>> GetNameAsync(string name, params string[] IncludeList);
    }
}
