using Blog123.Domain.Entities.Abstract;
using Blog123.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Domain.Entities.Concrete
{
    public class Category : IBaseEntity, IBaseEntityId<int>
    {

        //public Category()
        //{
        //    Posts = new List<Post>();
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }

        //public List<Post> Posts { get; set; }
        public List<CategoryPost> Posts { get; set; }
    }
}
