using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository : BaseRepository<User>
    {
        Task<User> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<User>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<User>> GetRoleNameAsync(string roleName, params string[] IncludeList);
        Task<List<User>> GetDepartmentNameAsync(string departmentName, params string[] IncludeList);
        Task<List<User>> GetCompanyNameAsync(string companyName, params string[] IncludeList);
    }
}
