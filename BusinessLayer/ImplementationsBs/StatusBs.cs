using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.StatusDto;
using Model.Dtos.UserDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class StatusBs : IStatusBs
    {
        private readonly IStatusRepository _repo;
        private readonly IMapper _mapper;
        public StatusBs(IStatusRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<StatusGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<StatusGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<StatusGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<StatusGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<StatusGetDto>> GetStatusAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<StatusGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<Status> InsertAsync(StatusPostDto entity)
        {
            var val = _mapper.Map<Status>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Status> UpdateAsync(StatusPutDto entity)
        {
            var val = _mapper.Map<Status>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
