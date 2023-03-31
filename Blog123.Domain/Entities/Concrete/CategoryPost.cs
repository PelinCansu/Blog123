using Blog123.Domain.Entities.Abstract;
using Blog123.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Domain.Entities.Concrete
{
    public class CategoryPost:IBaseEntity
    { 
        public Category Category { get; set; }
        public Post Post { get; set; }
        public int CategoryId { get; set; }
        public Guid PostId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
