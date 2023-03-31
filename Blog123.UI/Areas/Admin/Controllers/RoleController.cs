using AutoMapper;
using Blog123.Application.Models.DTOs.AppRoleDTOs;
using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Application.Services.AppRoleService;
using Blog123.Application.Services.AppUserService;
using Blog123.Domain.Entities.Concrete;
using Blog123.UI.Areas.Admin.ViewModels.CategoryVMs;
using Blog123.UI.Areas.Admin.ViewModels.RoleVMs;
using Blog123.UI.Areas.Admin.ViewModels.UserVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Data;
using System.Runtime.Intrinsics.X86;

namespace Blog123.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
	{
		IAppUserService _appUserService;
		IAppRoleService _appRoleService;

		IMapper _mapper;



		public RoleController(IAppRoleService appRoleService, IMapper mapper, IAppUserService appUserService)
		{
			this._mapper = mapper;
			this._appRoleService = appRoleService;
			this._appUserService = appUserService;


		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Create()
		{
			RoleCreateVM vm = new RoleCreateVM();
			Guid id = Guid.NewGuid();
			vm.Id = id;
			//vm.Status = Domain.Enums.Status.Active;
			//vm.CreatedDate = DateTime.Now;
			//vm.CreatedBy = "Admin";
			//vm.ModifiedDate = DateTime.Now;

			return View(vm);
		}
		[HttpPost]
		public async Task<IActionResult> Create(RoleCreateVM vm)
		{
			if (ModelState.IsValid)
			{
				try
				{

					var dto = _mapper.Map<AppRoleCreateDTO>(vm);
					await _appRoleService.Create(dto);
					return RedirectToAction("List", "Role");


				}
				catch (Exception ex)
				{

					TempData["error"] = ex.Message;
				}
			}

			return View(vm);
		}

		public async Task<IActionResult> List()
		{
			List<AppRoleListDTO> list1 = await _appRoleService.AllRoles();
			List<RoleListVM> list2 = _mapper.Map<List<RoleListVM>>(list1);
			return View(list2);
		}

		public async Task<IActionResult> ListUsers()
		{
			
		List<UserListVM> list= _mapper.Map<List<UserListVM>>(await _appUserService.GetUsers());
			return View(list);
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			await _appRoleService.Remove(id);
			return RedirectToAction("List", "Role");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{


			var role = await _appRoleService.GetById(id);
			var roleVM = _mapper.Map<RoleUpdateVM>(role);
			return View(roleVM);



		}
		[HttpPost]
		public async Task<IActionResult> Edit(RoleUpdateVM vm)
		{
			if (ModelState.IsValid)
			{
				try
				{
					AppRoleUpdateDTO dto = _mapper.Map<AppRoleUpdateDTO>(vm);
					await _appRoleService.Edit(dto);
					return RedirectToAction("List", "Role");
				}
				catch (Exception ex)
				{

					TempData["error"] = ex.Message;
				}
			}

			return View(vm);
		}


		public async Task<IActionResult> RoleAssign(Guid id)
		{
			AppUser user = await _appUserService.GetById(id);
			List<RoleListVM> allRoles =  _mapper.Map<List<RoleListVM>>(await _appRoleService.AllRoles());

			List<string> userRoles = await _appUserService.GetUserAssignedRoles(user) as List<string>;

			List<UserRoleAssignVM> assignRoles = new List<UserRoleAssignVM>();
			
			allRoles.ForEach(role => assignRoles.Add(new UserRoleAssignVM

			{ HasAssign=userRoles.Contains(role.Name),
				Id = role.Id,
				Name = role.Name
			}));

			return View(assignRoles);
		}
		[HttpPost]
		public async Task<ActionResult> RoleAssign(List<UserRoleAssignVM> modelList, Guid id)
		{
			AppUser user = await _appUserService.GetById(id);
			foreach (UserRoleAssignVM role in modelList)
			{
				if (role.HasAssign)
					await _appUserService.AddRole(user, role.Name);
				else
					await _appUserService.RemoveRole(user, role.Name);
			}
			return RedirectToAction("ListUsers", "Role");
		}

	}


}



