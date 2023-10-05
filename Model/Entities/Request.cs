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
        public int ID { get; set; }
        public string? Description { get; set; }
        public int? DesiredQuantity { get; set; }
        public int? CategoryID { get; set; }
        public int? UserID { get; set; }
        public int? StatusID { get; set; }
        public string? CategoryName { get; set; }
        public string? UserName { get; set; }
        public string? StatusName { get; set; }

        //public enum Status
        //{
        //    Beklemede = 1,
        //    Onaylandı = 2,
        //    Reddedildi = 3,
        //    TeminEdildi = 4
        //}


    }
}