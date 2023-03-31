using AutoMapper;
using Blog123.Application.Services.PostService;
using Blog123.UI.Areas.Author.ViewModels;
using Blog123.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog123.UI.Controllers
{
    public class HomeController : Controller
    {

        IPostService _postService;
        IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IPostService postService, IMapper mapper)
        {
            _logger = logger;
            this._postService = postService;
            this._mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
           //var posts= _mapper.Map<PostListVM>(await _postService.GetDefaults(x=>x.Status==Domain.Enums.Status.Active));
           return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}