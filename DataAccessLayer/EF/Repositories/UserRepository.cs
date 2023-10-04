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
        public async Task<User> FindByIdAsync(int userId, params string[] IncludeList)
        {
            return await FindAsync(usr => usr.UserID == userId, IncludeList);
        }

        public async Task<List<User>> FindUserRoleAsync(string role, params string[] IncludeList)
        {
            return await GetAllAsync(usr=>usr.UserRole.Contains(role), IncludeList);
        }
    }
}
