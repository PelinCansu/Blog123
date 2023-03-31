using Blog123.Application.Models.DTOs.AppRoleDTOs;
using Blog123.Application.Models.DTOs.AppUserDTOs;
using Blog123.Application.Models.DTOs.AuthorDTOs;
using Blog123.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Services.AppRoleService
{
    public interface IAppRoleService
    {
        Task Create(AppRoleCreateDTO appRoleCreateDTO);
        Task Edit(AppRoleUpdateDTO appRoleUpdateDTO);
        Task Remove(Guid id);

      
        Task<List<AppRoleListDTO>> AllRoles();
        //Task<List<AppUser>> AllUsers();
        Task<AppRoleUpdateDTO> GetById(Guid id);
        Task<bool> IsRoleExists(string approleName);

        Task RoleAssign(Guid id, List<UserRoleAssignDTO> roleDTOlist);
    }
}
