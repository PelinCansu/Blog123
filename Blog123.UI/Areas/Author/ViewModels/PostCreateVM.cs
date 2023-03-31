using Blog123.Domain.Entities.Concrete;

namespace Blog123.UI.Areas.Author.ViewModels
{
    public class PostCreateVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
        public Guid AppUserId { get; set; }

        public string Summary { get; set; }
        public string MinRead { get; set; }
        public ushort ViewCount { get; set; }
        public bool HasCategory { get; set; }

        public List<Category>? Categories { get; set; } 
    }
}
