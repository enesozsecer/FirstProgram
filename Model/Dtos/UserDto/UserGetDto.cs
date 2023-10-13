using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.UserDto
{
    public class UserGetDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string? AuthenticateName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CompanyName { get; set; }
        public Guid? AuthenticateID { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? CompanyID { get; set; }
    }
}
