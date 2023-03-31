using Blog123.Domain.Entities.Abstract;
using Blog123.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Domain.Entities.Concrete
{
    public class Post : IBaseEntity, IBaseEntityId<Guid>
    {

        //public Post()
        //{
        //    Categories = new List<Category>();
        //}
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public Guid AuthorID { get; set; }
        public Author Author { get; set; }
        public string MinRead { get; set; }
        public ushort ViewCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
       
        //Navigate
        public List<Like> Likes { get; set; }
        //public List<Category> Categories { get; set; }
        public List<CategoryPost> Categories { get; set; }

}
}
