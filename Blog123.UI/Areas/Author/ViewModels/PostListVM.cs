using Blog123.Domain.Entities.Concrete;

namespace Blog123.UI.Areas.Author.ViewModels
{
    public class PostListVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
       
        public Blog123.Domain.Entities.Concrete.Author Author { get; set; }
		public string Summary { get; set; }
        public string MinRead { get; set; }
        public ushort ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }

		//Navigate
		public List<Category> Categories { get; set; }
        public List<Like> Likes { get; set; }
    }
}
