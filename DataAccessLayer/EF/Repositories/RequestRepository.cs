using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;

namespace DataAccessLayer.EF.Repositories
{
    public class RequestRepository : BaseRepository<Request, FirstProgramContext>, IRequestRepository
    {
        public async Task<Request> GetByIdAsync(int Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Request>> GetCategoryNameAsync(string categoryName, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.CategoryName == categoryName, IncludeList);
        }

        public async Task<List<Request>> GetDescriptionAsync(string description, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Description.Contains(description), IncludeList);
        }

        public async Task<List<Request>> GetStatusNameAsync(string statusName, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.StatusName.Contains(statusName), IncludeList);
        }

        public async Task<List<Request>> GetUserNameAsync(string userName, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.UserName.Contains(userName), IncludeList);
        }
    }
}
