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
    public class InvoiceRepository : BaseRepository<Invoice, FirstProgramContext>, IInvoiceRepository
    {
        public async Task<Invoice> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Invoice>> GetSupplierIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.SupplierID == Id, IncludeList);
        }

        public async Task<List<Invoice>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }
    }
}
