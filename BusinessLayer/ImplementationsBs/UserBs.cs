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
        public async Task DeleteAsync(int id)
        {
            var user = await _repo.FindByIdAsync(id);
            await _repo.DeleteAsync(user);
        }

        public async Task<User> FindByIdAsync(int userId, params string[] IncludeList)
        {
            var user = await _repo.FindByIdAsync(userId, IncludeList);
            if (user != null)
            {
                var dto = _mapper.Map<User>(user);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<User>> FindUserRoleAsync(string role, params string[] IncludeList)
        {
            var user = await _repo.FindUserRoleAsync(role, IncludeList);
            if (user.Count > 0) 
            {
                var userList=_mapper.Map<List<User>>(user);
                return userList;
            }
            throw new NotImplementedException();
        }

        public async Task<User> InsertAsync(User entity)
        {
            var user = _mapper.Map<User>(entity);
            var insertedUser = await _repo.InsertAsync(user);
            return insertedUser;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            var user = _mapper.Map<User>(entity);
            var insertedUser = await _repo.UpdateAsync(user);
            return insertedUser;
        }


        public async Task<AccessToken> AuthenticateAsync(LoginDto login)
        {
            var user = await _repo.FindAsync(x => x.UserName == login.UserName && x.UserPassword == login.UserPassword);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,user.UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AccessToken accessToken = new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = (DateTime)tokenDescriptor.Expires,
                UserName = user.UserName,
                UserID = user.UserID,
            };
            return await Task.Run(() => accessToken);
        }
    }
}
