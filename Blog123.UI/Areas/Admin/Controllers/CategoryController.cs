using AutoMapper;
using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Application.Services.CategoryServices;
using Blog123.UI.Areas.Admin.ViewModels.CategoryVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Blog123.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }


        //Tüm aktif kategorileri Listelenir.
        public async Task<IActionResult> GetAllActiveCategories()
        {

            var listDTO = await _categoryService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var listVM = _mapper.Map<List<CategoryListVM>>(listDTO);

            return View(listVM);
        }

        public async Task<IActionResult> GetAllCategories()
        {

            var listDTO = await _categoryService.AllCategories();
            var listVM = _mapper.Map<List<CategoryListVM>>(listDTO);

            return View(listVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(CategoryCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dto = _mapper.Map<CategoryCreateDTO>(vm);
                    await _categoryService.Create(dto);
                    return RedirectToAction("GetAllCategories");

                }
                catch (Exception ex)
                {

                    TempData["error"] = ex.Message;
                }
            }

            return View(vm);
        }


        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.Remove(id);
                return RedirectToAction("GetAllCategories");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllCategories");

            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var updateDto = await _categoryService.GetById(id);
            var updateVm = _mapper.Map<CategoryEditVM>(updateDto);

            return View(updateVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditVM vm)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var updateDto = _mapper.Map<CategoryUpdateDTO>(vm);
                    await _categoryService.Edit(updateDto);
                    return RedirectToAction("GetAllCategories");
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
