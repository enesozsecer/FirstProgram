using Core.DataAccessLayer.InterfacesDal;
using Model.Dtos.RequestDto;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IRequestRepository : BaseRepository<Request>
    {
        Task<Request> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Request>> GetDescriptionAsync(string description, params string[] IncludeList);
        Task<List<Request>> GetCategoryIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Request>> GetUserIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Request>> GetStatusIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Request>> GetUserDepIdAsync(Guid Id, params string[] IncludeList);
    }
}
