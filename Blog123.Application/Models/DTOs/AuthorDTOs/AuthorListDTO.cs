using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Models.DTOs.AuthorDTOs
{
    public class AuthorListDTO
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
        public List<Post> Posts { get; set; }
    }
}
