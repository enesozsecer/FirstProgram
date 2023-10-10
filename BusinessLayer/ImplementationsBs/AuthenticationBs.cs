using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.AuthenticateDto;
using Model.Dtos.CategoryDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class AuthenticationBs : IAuthenticationBs
    {
        private readonly IAuthenticateRepository _repo;
        private readonly IMapper _mapper;
        public AuthenticationBs(IAuthenticateRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<AuthenticateGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<AuthenticateGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<AuthenticateGetDto>> GetAuthenticationAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<AuthenticateGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<List<AuthenticateGetDto>> GetRoleAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<AuthenticateGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Authenticate> InsertAsync(AuthenticatePostDto entity)
        {
            var val = _mapper.Map<Authenticate>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Authenticate> UpdateAsync(AuthenticatePutDto entity)
        {
            var val = _mapper.Map<Authenticate>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
