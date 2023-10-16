using AutoMapper;
using BusinessLayer.InterfacesBs;
using Core.Helpers;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model.Dtos.UserLoginDto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.ImplementationsBs
{
    public class AuthBs:IAuthBs
    {
        private readonly IUserRepository _repo;
        private readonly AppSettings _appSettings;
        public AuthBs(IUserRepository repo, IOptions<AppSettings> appSettings)
        {
            _repo = repo;
            _appSettings = appSettings.Value;
        }
        public async Task<AccessToken> AuthenticateAsync(LoginDto login)
        {

            var val = await _repo.GetAsync(x => x.Email == login.UserName && x.Password == login.UserPassword);
            if (val == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email,val.ID.ToString()),
                    new Claim(ClaimTypes.Role,val.AuthenticateID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AccessToken accessToken = new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = (DateTime)tokenDescriptor.Expires,
                UserName = val.Email,
                UserID = val.ID,
                AuthenticationID = val.ID,
            };
            return await Task.Run(() => accessToken);
        }
    }
}
