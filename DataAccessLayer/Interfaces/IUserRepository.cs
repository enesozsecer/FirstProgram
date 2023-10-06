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
        Task<User> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<User>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<User>> GetRoleIdAsync(Guid Id, params string[] IncludeList);
        Task<List<User>> GetDepartmentIdAsync(Guid Id, params string[] IncludeList);
        Task<List<User>> GetCompanyIdAsync(Guid Id, params string[] IncludeList);
    }
}
