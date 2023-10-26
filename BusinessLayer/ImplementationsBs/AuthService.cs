using AutoMapper;
using BusinessLayer.InterfacesBs;
using Core.Utilities.Response;
using Core.Utilities.Security.Token;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Model.Dtos.UserDto;
using Model.Dtos.UserLoginDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BusinessLayer.ImplementationsBs
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly IUserBs _userBs;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthService(IUserBs userBs, ITokenService tokenService, IMapper mapper, IUserRepository repo)
        {
            _tokenService = tokenService;
            _userBs = userBs;
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ApiDataResponse<User>> LoginAsync(LoginDto loginDto)
        {
            var user = await _repo.GetAsync(x => x.Email == loginDto.UserName && x.Password == loginDto.UserPassword);
            if (user == null)
            {
                return new ErrorApiDataResponse<User>(null, "kullanıcı bulunamadı");
            }
            else
            {
                if (user.TokenExpireDate == null || string.IsNullOrEmpty(user.Token))
                {
                    var accessToken = _tokenService.CreateToken(user.ID, user.Name,user.RoleID);
                    var userUpdateDto = _mapper.Map<UserPutDto>(user);
                    userUpdateDto.Token = accessToken.Token;
                    userUpdateDto.TokenExpireDate = accessToken.Expiration;
                    var resultNewUserUpdateDto = await _userBs.UpdateAsync(userUpdateDto);
                    var userDto = _mapper.Map<User>(resultNewUserUpdateDto);
                    return new SuccessApiDataResponse<User>(userDto, "giriş başarılı");

                }
                if (user.TokenExpireDate < DateTime.Now)
                {
                    var accessToken = _tokenService.CreateToken(user.ID, user.Name,user.RoleID);
                    var userUpdateDto = _mapper.Map<UserPutDto>(user);
                    userUpdateDto.Token = accessToken.Token;
                    userUpdateDto.TokenExpireDate = accessToken.Expiration;
                    var resultNewUserUpdateDto = await _userBs.UpdateAsync(userUpdateDto);
                    var userDto = _mapper.Map<User>(resultNewUserUpdateDto);
                    return new SuccessApiDataResponse<User>(userDto, "giriş başarılı");
                }
            }
            return new SuccessApiDataResponse<User>(user, "giriş başarılı");
        }
    }
}
