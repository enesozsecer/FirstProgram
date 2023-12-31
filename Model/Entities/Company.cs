﻿using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Company : IEntities
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public List<Department>? Department { get; set; }
    }
}
