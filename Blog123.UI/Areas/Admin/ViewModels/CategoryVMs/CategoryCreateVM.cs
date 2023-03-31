using Blog123.Domain.Enums;

namespace Blog123.UI.Areas.Admin.ViewModels.CategoryVMs
{
    public class CategoryCreateVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Status Status => Status.Active;
    }
}
