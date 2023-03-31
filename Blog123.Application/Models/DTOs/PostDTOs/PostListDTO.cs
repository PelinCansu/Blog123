using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Models.DTOs.PostDTOs
{
	public class PostListDTO
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public Guid AuthorId { get; set; }

		public Blog123.Domain.Entities.Concrete.Author Author { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Summary { get; set; }
		public string MinRead { get; set; }
		public ushort ViewCount { get; set; }

		//Navigate
		public List<Category> Categories { get; set; }
		public List<Like> Likes { get; set; }
	}
}
