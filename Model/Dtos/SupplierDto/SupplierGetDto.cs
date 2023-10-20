using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.SupplierDto
{
    public class SupplierGetDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string? CategoryName { get; set; }
    }
}
