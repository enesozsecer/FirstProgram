using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IRequestRepository : IBaseRepository<Request>
    {
        Task<List<Request>> GetByRequestType(string type, params string[] IncludeList);
        Task<Request> FindByIdAsync(int requestId, params string[] IncludeList);
        Task<List<Request>> GetByUserId(int userId, params string[] IncludeList);
        Task<List<Request>> GetByProductId(int productId, params string[] IncludeList);
    }
}
