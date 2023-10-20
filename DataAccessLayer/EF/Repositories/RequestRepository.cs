using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;

namespace DataAccessLayer.EF.Repositories
{
    public class RequestRepository : BaseRepository<Request, FirstProgramContext>, IRequestRepository
    {
        public async Task<Request> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Request>> GetCategoryIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.CategoryID== Id, IncludeList);
        }

        public async Task<List<Request>> GetDescriptionAsync(string description, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Description.Contains(description), IncludeList);
        }

        public async Task<List<Request>> GetStatusIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.StatusID == Id, IncludeList);
        }

        public async Task<List<Request>> GetUserIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.UserID == Id, IncludeList);
        }
        public async Task<List<Request>> GetUserDepIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.User.DepartmentID == Id, IncludeList);
        }
    }
}
