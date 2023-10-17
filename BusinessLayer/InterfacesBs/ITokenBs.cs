using Core.Utilities.Security.Token;
using Model.Dtos.UserLoginDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface ITokenBs
    {
        Task<AccessToken> AuthenticateAsync(LoginDto dto);
    }
}
