using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.ProductDto
{
    public class ProductGetDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public short? StockQuantity { get; set; }
        public decimal? ProductPrice { get; set; }

        public string? CategoryName { get; set; }
        public string? OfferName { get; set; }
        public string? InvoiceName { get; set; }
    }
}
