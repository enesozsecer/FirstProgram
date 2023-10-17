using Core.Utilities.Response;
using Model.Dtos.UserLoginDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IAuthService
    {
        Task<ApiDataResponse<User>> LoginAsync(LoginDto loginDto);
    }
}
