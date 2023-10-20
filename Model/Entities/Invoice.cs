using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Invoice : IEntities
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public short? OrderAmount { get; set; }
        public decimal? OrderPrice { get; set; }


        public List<Product>? Product { get; set; }
        public List<Offer>? Offer { get; set; }
        public Guid? SupplierID { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
