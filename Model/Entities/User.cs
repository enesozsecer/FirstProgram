using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User : IEntities
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string UserDepartment { get; set; }
        public string ProductID { get; set; }
        public string UserPassword { get; set; }
    }
}
