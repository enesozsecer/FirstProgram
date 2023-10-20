using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IInvoiceRepository : BaseRepository<Invoice>
    {
        Task<Invoice> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Invoice>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<Invoice>> GetSupplierIdAsync(Guid Id, params string[] IncludeList);
    }
}
