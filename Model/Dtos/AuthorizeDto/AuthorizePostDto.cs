using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.AuthorizeDto
{
    public class AuthorizePostDto
    {
        public Guid ID { get; set; }
        public string Role { get; set; }
    }
}
