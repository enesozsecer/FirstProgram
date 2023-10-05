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
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int? RoleID { get; set; }
        public int? DepartmentID { get; set; }
        public int? CompanyID { get; set; }
        public string? RoleName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CompanyName { get; set; }

    }
}
