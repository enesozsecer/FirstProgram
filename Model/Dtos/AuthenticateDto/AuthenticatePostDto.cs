using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.AuthenticateDto
{
    public class AuthenticatePostDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
