using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.CategoryDto;
using Model.Dtos.CompanyDto;
using Model.Dtos.DepartmentDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class CompanyBs : ICompanyBs
    {
        private readonly ICompanyRepository _repo;
        private readonly IMapper _mapper;
        public CompanyBs(ICompanyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<CompanyGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<CompanyGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<CompanyGetDto>> GetCompaniesAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<CompanyGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<List<CompanyGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<CompanyGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Company> InsertAsync(CompanyPostDto entity)
        {
            var val = _mapper.Map<Company>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Company> UpdateAsync(CompanyPutDto entity)
        {
            var val = _mapper.Map<Company>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
