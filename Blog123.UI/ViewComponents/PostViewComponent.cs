using AutoMapper;
using Blog123.Application.Services.PostService;
using Blog123.UI.Areas.Author.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog123.UI.ViewComponents
{
    public class PostViewComponent:ViewComponent
    {
        IPostService _postService;
        IMapper _mapper;
        public PostViewComponent(IPostService postService, IMapper mapper)
        {
            this._postService = postService;
            this._mapper = mapper;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<PostListVM> postLists = _mapper.Map<List<PostListVM>>(await _postService.GetPostsWithAuthors());
            List<PostListVM> list = postLists.Take(10).ToList();
            return View(list);
            
        }
    }
}
