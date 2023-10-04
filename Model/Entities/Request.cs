using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Request : IEntities
    {
        public int RequestID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string RequestType { get; set; }
        public int DesiredQuantity { get; set; }
    }
}
