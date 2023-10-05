using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IDepartmentBs
    {
        Task<Department> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<Department>> GetNameAsync(string name, params string[] IncludeList);
        Task<Department> InsertAsync(Department entity);
        Task<Department> UpdateAsync(Department entity);
        Task DeleteAsync(int id);
    }
}
