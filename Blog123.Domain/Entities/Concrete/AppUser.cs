
using Blog123.Domain.Entities.Abstract;
using Blog123.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Domain.Entities.Concrete
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {
        public AppUser()
        {
            this.Likes = new List<Like>();
        }

        public string? Address { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Status Status { get; set; }
       

        public List<Like> Likes { get; set; }
      
    }
}
