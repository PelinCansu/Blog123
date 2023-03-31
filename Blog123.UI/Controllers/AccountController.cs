using AutoMapper;
using Blog123.Application.Models.DTOs.AppUserDTOs;
using Blog123.Application.Services.AppUserService;
using Blog123.UI.Areas.Admin.ViewModels.UserVMs;
using Blog123.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Blog123.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IAppUserService _appUserService;
        IMapper _mapper;
        public AccountController(IAppUserService appUserService, IMapper mapper)
        {
            this._appUserService = appUserService;
            this._mapper = mapper;

        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegisterDTO>(vm);
                var result = await _appUserService.Register(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                    TempData["error"] = "Kayıt oluşturulurken hata oluştu.";
                }
            }

            return View(vm);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (ModelState.IsValid)
            {
                var _loginDto = _mapper.Map<LoginDTO>(vm);
                var result = await _appUserService.Login(_loginDto);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["error"] = "Giriş İşlemi Başarısız!!!";
            return View(vm);
        }

        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ProfileDetails(string userName)
        {

            var userInfo= _mapper.Map<UserListVM> (await _appUserService.GetByUserName(userName));
            return View(userInfo);
        }

		[HttpPost]
		public async Task<IActionResult> ProfileDetails(LoginVM vm)
		{

            return RedirectToAction("Index", "Home");
		}




	}
}
