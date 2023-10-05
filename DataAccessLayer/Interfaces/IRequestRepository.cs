using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IRequestRepository : BaseRepository<Request>
    {
        Task<Request> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<Request>> GetDescriptionAsync(string description, params string[] IncludeList);
        Task<List<Request>> GetCategoryNameAsync(string categoryName, params string[] IncludeList);
        Task<List<Request>> GetUserNameAsync(string userName, params string[] IncludeList);
        Task<List<Request>> GetStatusNameAsync(string statusName, params string[] IncludeList);
    }
}
