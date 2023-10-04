using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;

namespace DataAccessLayer.EF.Repositories
{
    public class RequestRepository : BaseRepository<Request, FirstProgramContext>, IRequestRepository
    {
        public async Task<Request> FindByIdAsync(int requestId, params string[] IncludeList)
        {
            return await FindAsync(req=>req.RequestID==requestId, IncludeList);
        }

        public async Task<List<Request>> GetByProductId(int productId, params string[] IncludeList)
        {
            return await GetAllAsync(req => req.ProductID == productId, IncludeList);
        }

        public async Task<List<Request>> GetByRequestType(string type, params string[] IncludeList)
        {
            return await GetAllAsync(req => req.RequestType == type, IncludeList);
        }

        public async Task<List<Request>> GetByUserId(int userId, params string[] IncludeList)
        {
            return await GetAllAsync(req => req.UserID == userId, IncludeList);
        }
    }
}
