using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto
{
    public class RequestPostDto
    {
        public Guid ID { get; set; }
        public string? Description { get; set; }
        public int? DesiredQuantity { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? UserID { get; set; }
        public Guid? StatusID { get; set; }
    }
}
