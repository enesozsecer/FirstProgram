﻿using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Supplier : IEntities
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid CategoryID { get; set; }
        public Category? Category { get; set; }
        public List<Offer>? Offer { get; set; }
        public List<Invoice>? Invoice { get; set; }
    }
}
