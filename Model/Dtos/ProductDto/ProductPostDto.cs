using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.ProductDto
{
    public class ProductPostDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public short? StockQuantity { get; set; }
        public decimal? ProductPrice { get; set; }

        public Guid? CategoryID { get; set; }
        public Guid? OfferID { get; set; }
    }
}
