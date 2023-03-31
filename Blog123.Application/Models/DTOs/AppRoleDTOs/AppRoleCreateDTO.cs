using Blog123.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blog123.Application.Models.DTOs.AppRoleDTOs
{
    public class AppRoleCreateDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Rolün belirtilmesi zorunludur.")]
        [Display(Name = "Rol:")]
        public string Name { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public Status Status { get; set; }

       
    }
}
