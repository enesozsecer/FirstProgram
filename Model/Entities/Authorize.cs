using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Authorize : IEntities
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
