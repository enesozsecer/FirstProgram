using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.InvoiceDto
{
    public class InvoiceGetDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string? SupplierName { get; set; }
        public short? OrderAmount { get; set; }
        public decimal? OrderPrice { get; set; }
    }
}
