using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Models.DTOs.AuthorDTOs
{
    public class AuthorCreateDTO
    {
        public string UserId { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public Status Status => Status.Active;
        //public List<AppUser> Users { get; set; }
    }
}
