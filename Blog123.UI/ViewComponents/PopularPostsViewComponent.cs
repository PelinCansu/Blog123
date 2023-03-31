using AutoMapper;
using Blog123.Application.Services.AuthorService;
using Blog123.Application.Services.PostService;
using Blog123.UI.Areas.Author.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog123.UI.ViewComponents
{
	public class PopularPostsViewComponent:ViewComponent
	{
		IPostService _postService;
		IMapper _mapper;
		
		public PopularPostsViewComponent(IPostService postService, IMapper mapper, IAuthorService authorService)
		{
			this._postService = postService;
			this._mapper = mapper;
			

		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<PostListVM> postLists = _mapper.Map<List<PostListVM>>(await _postService.GetPostsWithAuthors());

			var list= postLists.OrderBy(x => x.ViewCount).ThenBy(x => x.Title).Take(5).ToList();

			return View(list);

		}
	}
}
