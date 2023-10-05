using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;

namespace DataAccessLayer.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, FirstProgramContext>, ICategoryRepository
    {
        public async Task<Category> GetByIdAsync(int Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Category>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }
    }
}
