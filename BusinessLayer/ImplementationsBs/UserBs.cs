using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Entities;
using Core.Helpers;
using Model.Dtos.UserLoginDto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using System.Data;

namespace BusinessLayer.ImplementationsBs
{
    public class UserBs : IUserBs
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UserBs(IUserRepository repo, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repo = repo; _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }
        public async Task<User> InsertAsync(User entity)
        {
            var val = _mapper.Map<User>(entity);
            var insertedUser = await _repo.InsertAsync(val);
            return insertedUser;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            var val = _mapper.Map<User>(entity);
            var insertedUser = await _repo.UpdateAsync(val);
            return insertedUser;
        }


        public async Task<User> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<User>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<User>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }


        

        public async Task<List<User>> GetRoleIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetRoleIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<User>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetDepartmentIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetDepartmentIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<User>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetCompanyIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetCompanyIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<User>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }
    }
}
