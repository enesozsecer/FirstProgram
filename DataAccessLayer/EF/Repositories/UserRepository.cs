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
    public class UserRepository : BaseRepository<User, FirstProgramContext>, IUserRepository
    {
        public async Task<User> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<User>> GetCompanyIdAsync(Guid Id, params string[] IncludeList)//
        {
            return await GetAllAsync(val => val.DepartmentID==Id, IncludeList);
        }

        public async Task<List<User>> GetDepartmentIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.DepartmentID == Id, IncludeList);
        }

        public async Task<List<User>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }

        public async Task<List<User>> GetRoleIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.AuthenticateID == Id, IncludeList);
        }
    }
}
