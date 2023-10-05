using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product : IEntities
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public short? StockQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public Category? Category { get; set; }
        public User? User { get; set; }
    }
}
