using Blog123.Application.Models.DTOs.AppUserDTOs;
using Blog123.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Services.AppUserService
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO registerDTO);
        Task<SignInResult> Login(LoginDTO loginDTO);
        Task LogOut();
        Task<List<UserListDTO>> GetUsers();
        Task<AppUser> GetById(Guid id);
        Task<AppUser> GetByUserName(string userName);
        Task<List<string>> GetUserAssignedRoles(AppUser appUser);
        Task AddRole(AppUser appUser, string appRoleName);
        Task RemoveRole(AppUser appUser, string appRoleName);
    }
}
