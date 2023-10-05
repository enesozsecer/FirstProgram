using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class CompanyBs:ICompanyBs
    {
        private readonly ICompanyRepository _repo;
        private readonly IMapper _mapper;
        public CompanyBs(ICompanyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(int id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<Company> GetByIdAsync(int Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<Company>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Company>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Company>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Company> InsertAsync(Company entity)
        {
            var val = _mapper.Map<Company>(entity);
            var insertedUser = await _repo.InsertAsync(val);
            return insertedUser;
        }

        public async Task<Company> UpdateAsync(Company entity)
        {
            var val = _mapper.Map<Company>(entity);
            var insertedUser = await _repo.UpdateAsync(val);
            return insertedUser;
        }
    }
}
