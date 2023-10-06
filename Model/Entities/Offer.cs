using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Offer : IEntities
    {
        public Guid ID { get; set; }
        public string? ProductName { get; set; }
        public short? ProductAmount { get; set; }
        public decimal? OffertPrice { get; set; }


        public List<Request>? Request { get; set; }


        public Guid? ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
