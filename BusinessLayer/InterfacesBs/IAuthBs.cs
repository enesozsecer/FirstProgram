using Core.Helpers;
using Model.Dtos.UserLoginDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IAuthBs
    {
        Task<AccessToken> AuthenticateAsync(LoginDto dto);
    }
}
