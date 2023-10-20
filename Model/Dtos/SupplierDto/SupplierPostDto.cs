using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.SupplierDto
{
    public class SupplierPostDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid? CategoryID { get; set; }
    }
}
