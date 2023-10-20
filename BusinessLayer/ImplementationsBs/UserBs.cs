using AutoMapper;
using BusinessLayer.InterfacesBs;
using Core.Utilities.Response;
using Core.Utilities.Security.Token;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.Options;
using Model.Dtos.UserDto;
using Model.Entities;
using System.Linq.Expressions;

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
        public async Task<User> InsertAsync(UserPostDto entity)
        {
            var val = _mapper.Map<User>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<User> UpdateAsync(UserPutDto entity)
        {
            var val = _mapper.Map<User>(entity);
            val.Token = entity.Token;
            val.TokenExpireDate = entity.TokenExpireDate;
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
        public async Task<UserGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<UserGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<UserGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<UserGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }
        public async Task<List<UserGetDto>> GetRoleIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetRoleIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<UserGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<UserGetDto>> GetDepartmentIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetDepartmentIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<UserGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<UserGetDto>> GetCompanyIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetCompanyIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<UserGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<UserGetDto>> GetUsersAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<UserGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<ApiDataResponse<UserGetDto>> GetAsync(Expression<Func<User, bool>> predicate, params string[] includeList)
        {
            var user= await _repo.GetAsync(predicate, includeList);
            if (user!=null)
            {
                var userDto = _mapper.Map<UserGetDto>(user);
                return new SuccessApiDataResponse<UserGetDto>(userDto,"Listelendi");
            }
            return new ErrorApiDataResponse<UserGetDto>(null, "Listelenmedi");
        }
    }
}
