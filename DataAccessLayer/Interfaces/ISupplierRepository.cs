using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ISupplierRepository : BaseRepository<Supplier>
    {
        Task<Supplier> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Supplier>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<Supplier>> GetCategoryIdAsync(Guid Id, params string[] IncludeList);
    }
}
