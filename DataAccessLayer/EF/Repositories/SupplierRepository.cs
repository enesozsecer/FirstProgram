using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier, FirstProgramContext>, ISupplierRepository
    {
        public async Task<Supplier> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Supplier>> GetCategoryIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.CategoryID == Id, IncludeList);
        }

        public async Task<List<Supplier>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }
    }
}
