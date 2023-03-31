using Blog123.Domain.Enums;

namespace Blog123.UI.Areas.Admin.ViewModels.CategoryVMs
{
    public class CategoryEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Status Status { get; set; }

    }
}
