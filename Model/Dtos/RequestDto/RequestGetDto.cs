using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto
{
    public class RequestGetDto
    {
        public int RequestID { get; set; }
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public string RequestType { get; set; }
        public int DesiredQuantity { get; set; }
    }
}
