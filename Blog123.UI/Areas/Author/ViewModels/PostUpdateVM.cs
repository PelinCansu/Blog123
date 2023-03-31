﻿using Blog123.Domain.Entities.Concrete;

namespace Blog123.UI.Areas.Author.ViewModels
{
    public class PostUpdateVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }

        public string Summary { get; set; }
        public string MinRead { get; set; }
        public ushort ViewCount { get; set; }
        public List<Category> Categories { get; set; }
    }
}
