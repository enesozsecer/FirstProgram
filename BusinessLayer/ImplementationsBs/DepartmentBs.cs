using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.DepartmentDto;
using Model.Dtos.ProductDto;
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

        public async Task<DepartmentGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<DepartmentGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentGetDto>> GetDepartmentsAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<DepartmentGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<List<DepartmentGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<DepartmentGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Department> InsertAsync(DepartmentPostDto entity)
        {
            var val = _mapper.Map<Department>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Department> UpdateAsync(DepartmentPutDto entity)
        {
            var val = _mapper.Map<Department>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
