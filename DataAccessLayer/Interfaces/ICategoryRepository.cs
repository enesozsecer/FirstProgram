using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICategoryRepository:BaseRepository<Category>
    {
        Task<Category> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<Category>> GetNameAsync(string name, params string[] IncludeList);
    }
}
