using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Department : IEntities
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }

        public List<User>? User { get; set; }
        public Guid CompanyID { get; set; }
        public Company? Company { get; set; }
    }
}
