using Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserCore: AuditEntity
    {
        public string UserName { get; set; }
        public Guid RefreshToken { get; set; }
        public int UserTypeID { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
    }
}
