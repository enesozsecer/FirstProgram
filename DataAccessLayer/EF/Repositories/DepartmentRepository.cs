using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Repositories
{
    public class DepartmentRepository : BaseRepository<Department, FirstProgramContext>, IDepartmentRepository
    {
        public async Task<Department> GetByIdAsync(int Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Department>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }
    }
}
