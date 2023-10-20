using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.InvoiceDto;
using Model.Dtos.SupplierDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class InvoiceBs : IInvoiceBs
    {
        private readonly IInvoiceRepository _repo;
        private readonly IMapper _mapper;
        public InvoiceBs(IInvoiceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<InvoiceGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<InvoiceGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<InvoiceGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<InvoiceGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<InvoiceGetDto>> GetInvoicesAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<InvoiceGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }
        public async Task<List<InvoiceGetDto>> GetSupplierIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetSupplierIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<InvoiceGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Invoice> InsertAsync(InvoicePostDto entity)
        {
            var val = _mapper.Map<Invoice>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Invoice> UpdateAsync(InvoicePutDto entity)
        {
            var val = _mapper.Map<Invoice>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
