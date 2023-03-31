using AutoMapper;
using Blog123.Application.Models.DTOs.AuthorDTOs;
using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Application.Models.DTOs.PostDTOs;
using Blog123.Application.Services.AppUserService;
using Blog123.Application.Services.AuthorService;
using Blog123.Application.Services.CategoryServices;
using Blog123.Application.Services.PostService;
using Blog123.Domain.Entities.Concrete;
using Blog123.UI.Areas.Admin.ViewModels.AuthorVMs;
using Blog123.UI.Areas.Admin.ViewModels.CategoryVMs;
using Blog123.UI.Areas.Author.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Blog123.UI.Areas.Author.Controllers
{
    [Area("Author")]
    [Authorize(Roles = "Yazar")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IAppUserService _appuserService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;



        public PostController(IPostService postService, IMapper mapper, ICategoryService categoryService, IAppUserService appuserService, IAuthorService authorService)
        {
            this._postService = postService;
            this._categoryService = categoryService;
            this._appuserService = appuserService;
            this._authorService = authorService;

            _mapper = mapper;

        }


        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetAllPosts(string userName)
        {

            var listDTO = await _postService.GetDefaults(x => x.Author.UserName == userName);
            TempData["userName"] = userName;
            var listVM = _mapper.Map<List<PostListVM>>(listDTO);

            return View(listVM);

        }


        [HttpGet]
        public async Task<IActionResult> Create(string userName)
        {
            PostCreateVM vm = new PostCreateVM();
            vm.Id = Guid.NewGuid();

            AppUser user = await _appuserService.GetByUserName(userName);
            
            List<AuthorListVM> list = _mapper.Map<List<AuthorListVM>>(await _authorService.GetDefaults(x => x.User.UserName == userName));

           

            vm.Categories = _mapper.Map<List<Category>>(await _categoryService.AllCategories());
         
            vm.AuthorID = list.First().Id;


          
            return View(vm);
        }



        [HttpPost]
        public async Task<IActionResult> Create(PostCreateVM vm, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try

                {
                    var dto = _mapper.Map<PostCreateDTO>(vm);


                    await _postService.Create(dto);


                    foreach (var item in collection)
                    {
                        if (item.Key == "Categories")
                        {

                            for (int i = 0; i < item.Value.Count; i++)
                            {
                               int id = Convert.ToInt32(item.Value[i]);

                               


                                await _postService.AddToCategory(id, vm.Id);

                              


                            }

                            
                        }
                    }

                  
                    

                    return RedirectToAction("GetAllPosts", new { userName = HttpContext.User.Identity.Name });
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }

            return View(vm);
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                
                return RedirectToAction("GetAllAuthors");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllAuthors");

            }

        }

      

        [HttpPost]
        public async Task<IActionResult> Edit(AuthorUpdateVM vm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var updateDto = _mapper.Map<AuthorUpdateDTO>(vm);
                    //await _authorService.Edit(updateDto);
                    return RedirectToAction("GetAllAuthors");
                }
                catch (Exception ex)
                {

                    TempData["error"] = ex.Message;
                }
            }

            return View(vm);
        }
    }
}
