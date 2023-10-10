using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.DepartmentDto
{
    public class DepartmentGetDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string CompanyName { get; set; }
    }
}
