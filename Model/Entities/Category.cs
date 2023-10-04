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
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
