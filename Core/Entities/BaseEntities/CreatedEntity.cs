using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Dtos;

namespace Core.Entities.BaseEntities
{
    public class CreatedEntity : ICreatedEntity
    {
        public int CreatedUserId { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime CreatedDate { get; set; }
    }
}
