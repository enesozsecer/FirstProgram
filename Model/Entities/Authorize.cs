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
        public int ID { get; set; }
        public string Role { get; set; }

        //public Role Role { get; set; }

        //public enum Role
        //{
        //    admin = 1,
        //    user = 2,
        //    supplier = 3,
        //    purchasingmanager = 4
        //}
    }
}
