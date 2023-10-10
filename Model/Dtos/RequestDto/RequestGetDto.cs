using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.RequestDto
{
    public class RequestGetDto
    {
        public Guid ID { get; set; }
        public string? Description { get; set; }
        public int? DesiredQuantity { get; set; }
        public string? CategoryName { get; set; }
        public string? UserName { get; set; }
        public string? StatusName { get; set; }
    }
}
