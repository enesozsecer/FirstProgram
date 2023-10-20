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
        public Guid ID { get; set; }
        public string? Description { get; set; }
        public int? DesiredQuantity { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? UserID { get; set; }
        public Guid? StatusID { get; set; }
        

        public Category? Category { get; set; }
        public User? User { get; set; }
        public Status? Status { get; set; }

        //public enum Status
        //{
        //    Beklemede = 1,
        //    Onaylandı = 2,
        //    Reddedildi = 3,
        //    TeminEdildi = 4
        //}


    }
}