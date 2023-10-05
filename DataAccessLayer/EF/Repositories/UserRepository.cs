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
        public async Task<User> GetByIdAsync(int Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<User>> GetCompanyNameAsync(string companyName, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.CompanyName.Contains(companyName), IncludeList);
        }

        public async Task<List<User>> GetDepartmentNameAsync(string departmentName, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.DepartmentName.Contains(departmentName), IncludeList);
        }

        public async Task<List<User>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }

        public async Task<List<User>> GetRoleNameAsync(string roleName, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.RoleName.Contains(roleName), IncludeList);
        }
    }
}
