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
        public Guid? RoleID { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? CompanyID { get; set; }

        public List<Request>? Request { get; set; }
        public Department? Department { get; set; }
        public Authorize Authorize { get; set; }

    }
}
