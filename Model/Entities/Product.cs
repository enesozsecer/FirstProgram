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
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public short StockQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public Category? Category { get; set; }
        public User? User { get; set; }
    }
}
