using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User : IEntities
    {

        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public List<Request>? Request { get; set; }
        public Guid? DepartmentID { get; set; }
        public Department? Department { get; set; }
        public Guid? AuthenticateID { get; set; }
        public Authenticate Authenticate { get; set; }
        public Guid? CompanyID { get; set; }
        public Company? Company { get; set; }

    }
}
