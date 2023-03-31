using System.ComponentModel.DataAnnotations;

namespace Blog123.UI.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı girilmesi zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola girilmesi zorunludur!")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}
