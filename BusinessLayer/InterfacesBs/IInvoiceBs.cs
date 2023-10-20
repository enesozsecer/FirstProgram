using Model.Dtos.InvoiceDto;
using Model.Dtos.SupplierDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IInvoiceBs
    {
        Task<List<InvoiceGetDto>> GetInvoicesAsync(params string[] IncludeList);
        Task<InvoiceGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<InvoiceGetDto>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<InvoiceGetDto>> GetSupplierIdAsync(Guid Id, params string[] IncludeList);
        Task<Invoice> InsertAsync(InvoicePostDto entity);
        Task<Invoice> UpdateAsync(InvoicePutDto entity);
        Task DeleteAsync(Guid id);
    }
}
