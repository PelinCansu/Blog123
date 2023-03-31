using System.ComponentModel.DataAnnotations;

namespace Blog123.UI.Areas.Admin.ViewModels.RoleVMs
{
    public class RoleUpdateVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Rolün belirtilmesi zorunludur.")]
        [Display(Name = "Rol:")]
        public string Name { get; set; }
    }
}
