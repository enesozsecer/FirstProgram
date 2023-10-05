using Core.DataAccessLayer.ImplementationsDal;
using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDepartmentRepository : BaseRepository<Department>
    {
        Task<Department> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<Department>> GetNameAsync(string name, params string[] IncludeList);
    }
}
