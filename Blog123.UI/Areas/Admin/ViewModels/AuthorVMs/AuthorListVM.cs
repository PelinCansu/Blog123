using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Enums;

namespace Blog123.UI.Areas.Admin.ViewModels.AuthorVMs
{
    public class AuthorListVM
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
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
