using AutoMapper;
using Blog123.Application.Services.PostService;
using Blog123.UI.Areas.Author.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog123.UI.ViewComponents
{
    public class SelectedPostsViewComponent:ViewComponent
    {
        IPostService _postService;
        IMapper _mapper;
        public SelectedPostsViewComponent(IPostService postService, IMapper mapper)
        {
            this._postService = postService;
            this._mapper = mapper;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
			List<PostListVM> postLists = _mapper.Map<List<PostListVM>>(await _postService.GetPostsWithAuthors());
			List<PostListVM> list = postLists.Take(3).ToList();
			return View(list);

		}
    }
}
