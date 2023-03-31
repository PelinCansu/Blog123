using Blog123.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Blog123.UI.Areas.Admin.ViewModels.RoleVMs
{
    public class RoleCreateVM
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
