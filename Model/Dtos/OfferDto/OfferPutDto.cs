using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.OfferDto
{
    public class OfferPutDto
    {
        public Guid ID { get; set; }
        public string? OfferName { get; set; }
        public short? OfferAmount { get; set; }
        public decimal? OffertPrice { get; set; }
    }
}
