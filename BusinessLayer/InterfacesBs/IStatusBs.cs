using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IStatusBs
    {
        Task<Status> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<Status>> GetNameAsync(string name, params string[] IncludeList);
        Task<Status> InsertAsync(Status entity);
        Task<Status> UpdateAsync(Status entity);
        Task DeleteAsync(int id);
    }
}
