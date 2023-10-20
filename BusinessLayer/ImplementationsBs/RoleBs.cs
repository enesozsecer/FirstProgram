using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.RoleDto;
using Model.Dtos.CategoryDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class RoleBs : IRoleBs
    {
        private readonly IRoleRepository _repo;
        private readonly IMapper _mapper;
        public RoleBs(IRoleRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<RoleGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<RoleGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<RoleGetDto>> GetRoleAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<RoleGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<List<RoleGetDto>> GetRoleAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<RoleGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Role> InsertAsync(RolePostDto entity)
        {
            var val = _mapper.Map<Role>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Role> UpdateAsync(RolePutDto entity)
        {
            var val = _mapper.Map<Role>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
