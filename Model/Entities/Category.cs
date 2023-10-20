using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Category : IEntities
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public List<Request>? Request { get; set; }
        public List<Product>? Product { get; set; }
        public List<Supplier> Supplier { get; set; }
    }
}
