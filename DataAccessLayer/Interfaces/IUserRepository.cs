using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> FindUserRoleAsync(string role, params string[] IncludeList);
        Task<User> FindByIdAsync(int userId, params string[] IncludeList);
    }
}
