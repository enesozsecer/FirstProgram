using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public Guid RoleID { get; set; }
    }
}
