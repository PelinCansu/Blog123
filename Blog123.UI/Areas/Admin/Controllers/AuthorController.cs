using AutoMapper;
using Blog123.Application.Models.DTOs.AuthorDTOs;
using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Application.Services.AppUserService;
using Blog123.Application.Services.AuthorService;
using Blog123.Application.Services.CategoryServices;
using Blog123.UI.Areas.Admin.ViewModels.AuthorVMs;
using Blog123.UI.Areas.Admin.ViewModels.CategoryVMs;
using Blog123.UI.Areas.Admin.ViewModels.RoleVMs;
using Blog123.UI.Areas.Admin.ViewModels.UserVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog123.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly IAppUserService _appUserService;
        public AuthorController(IAuthorService authorService, IMapper mapper, IAppUserService appUserService)
        {
            this._authorService = authorService;
            _mapper = mapper;
            _appUserService = appUserService;
        }


        public IActionResult Index()
        {
            return View();
        }


        //Tüm aktif kategorileri Listelenir.
        public async Task<IActionResult> GetAllActiveAuthors()
        {

            var listDTO = await _authorService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var listVM = _mapper.Map<List<AuthorListVM>>(listDTO);

            return View(listVM);
        }

        public async Task<IActionResult> GetAllAuthors()
        {

            var listDTO = await _authorService.AllAuthors();
            var listVM = _mapper.Map<List<AuthorListVM>>(listDTO);

            return View(listVM);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AuthorCreateVM vm = new AuthorCreateVM();
           
                var list= _mapper.Map<List<UserListVM>>(await _appUserService.GetUsers());


            TempData["listUsers"] = list;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(AuthorCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = _mapper.Map<AuthorCreateDTO>(vm);
                    _authorService.Create(dto);
                    return RedirectToAction("GetAllActiveAuthors");
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
                await _authorService.Remove(id);
                return RedirectToAction("GetAllAuthors");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllAuthors");

            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var updateDto = await _authorService.GetById(id);
            var updateVm = _mapper.Map<AuthorUpdateVM>(updateDto);

            return View(updateVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AuthorUpdateVM vm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var updateDto = _mapper.Map<AuthorUpdateDTO>(vm);
                    await _authorService.Edit(updateDto);
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

