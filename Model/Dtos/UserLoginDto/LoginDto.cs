using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.UserLoginDto
{
    public class LoginDto
    {
        public string? UserName { get; set; }
        public string? UserPassword { get ; set; }
        public bool? IsRememberMe { get; set; }
    }
}
