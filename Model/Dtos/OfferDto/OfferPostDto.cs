﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos.OfferDto
{
    public class OfferPostDto
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public short? OfferAmount { get; set; }
        public decimal? OfferPrice { get; set; }
        public Guid? ProductID { get; set; }
        public Guid? StatusID { get; set; }
        public Guid? InvoiceID { get; set; }
        public Guid? SupplierID { get; set; }
    }
}
