using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blog123.Application.Models.DTOs.AppUserDTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Kullanıcı Adı girilmedilir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola girilmelidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola Tekrarı girilmelidir")]
        [Compare("Password", ErrorMessage = "Parola ile Parola Tekrarı Aynı Değil")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Tekrarı")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email girilmelidir.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Adres")]
        public string Address { get; set; }
    }
}
