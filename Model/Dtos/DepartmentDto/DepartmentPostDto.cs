using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.DepartmentDto
{
    public class DepartmentPostDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public Guid CompanyID { get; set; }
    }
}
