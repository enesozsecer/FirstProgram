using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.InvoiceDto
{
    public class InvoicePutDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid? SupplierID { get; set; }
        public short? OrderAmount { get; set; }
        public decimal? OrderPrice { get; set; }
    }
}
