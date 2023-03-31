using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Enums;

namespace Blog123.UI.Areas.Admin.ViewModels.CategoryVMs
{
    public class CategoryListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; }

        //public List<Post> Posts { get; set; }

    }
}
