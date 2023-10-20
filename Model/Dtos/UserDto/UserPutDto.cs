﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.UserDto
{
    public class UserPutDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public Guid? RoleID { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? CompanyID { get; set; }
    }
}
