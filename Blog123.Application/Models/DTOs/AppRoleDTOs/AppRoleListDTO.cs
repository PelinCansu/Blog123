using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blog123.Application.Models.DTOs.AppRoleDTOs
{
    public class AppRoleListDTO
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
    }
}
