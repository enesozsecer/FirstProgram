using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.OfferDto
{
    public class OfferGetDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public short? OfferAmount { get; set; }
        public decimal? OfferPrice { get; set; }
        public string ProductName { get; set; }
        public string StatusName{ get; set; }
        public string? InvoiceName { get; set; }
        public string? SupplierName { get; set; }

    }
}
