using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IStatusRepository : BaseRepository<Status>
    {
        Task<Status> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Status>> GetNameAsync(string name, params string[] IncludeList);
    }
}
