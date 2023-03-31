using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Enums;

namespace Blog123.UI.Areas.Admin.ViewModels.AuthorVMs
{
    public class AuthorCreateVM
    {
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public Status Status => Status.Active;
        //public List<AppUser> Users { get; set; }

    }
}
