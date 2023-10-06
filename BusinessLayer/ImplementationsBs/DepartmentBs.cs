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
    public class DepartmentBs : IDepartmentBs
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;
        public DepartmentBs(IDepartmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<Department> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<Department>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Department>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Department> InsertAsync(Department entity)
        {
            var val = _mapper.Map<Department>(entity);
            var insertedUser = await _repo.InsertAsync(val);
            return insertedUser;
        }

        public async Task<Department> UpdateAsync(Department entity)
        {
            var val = _mapper.Map<Department>(entity);
            var insertedUser = await _repo.UpdateAsync(val);
            return insertedUser;
        }
    }
}
