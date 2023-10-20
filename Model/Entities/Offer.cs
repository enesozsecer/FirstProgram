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
        public string? Name { get; set; }
        public short? OfferAmount { get; set; }
        public decimal? OfferPrice { get; set; }




        public Guid? SupplierID { get; set; }
        public Supplier? Supplier { get; set; }
        public Guid? ProductID { get; set; }
        public Product? Product { get; set; }
        public Guid? StatusID { get; set; }
        public Status? Status { get; set; }
        public Guid? InvoiceID { get; set; }
        public Invoice? Invoice { get; set; }
    }
}
