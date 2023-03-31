using AutoMapper;
using Blog123.Application.Models.DTOs.AppRoleDTOs;
using Blog123.Application.Models.DTOs.AppUserDTOs;
using Blog123.Application.Models.DTOs.AuthorDTOs;
using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Application.Models.DTOs.PostDTOs;
using Blog123.Domain.Entities.Concrete;
using Blog123.UI.Areas.Admin.ViewModels.AuthorVMs;
using Blog123.UI.Areas.Admin.ViewModels.CategoryVMs;
using Blog123.UI.Areas.Admin.ViewModels.RoleVMs;
using Blog123.UI.Areas.Admin.ViewModels.UserVMs;
using Blog123.UI.Areas.Author.ViewModels;
using Blog123.UI.Models.ViewModels;

namespace Blog123.UI.MapperProfile
{
    public class MappingUI:Profile
    {
        public MappingUI()
        {
            CreateMap<RegisterDTO, RegisterVM>().ReverseMap();

            CreateMap<LoginDTO, LoginVM>().ReverseMap();

            CreateMap<CategoryCreateDTO, CategoryCreateVM>().ReverseMap();
            CreateMap<CategoryListDTO, CategoryListVM>().ReverseMap();
            CreateMap<CategoryEditVM, CategoryUpdateDTO>().ReverseMap();


            CreateMap<AuthorUpdateVM, AuthorUpdateDTO>().ReverseMap();
            CreateMap<AuthorListVM, AuthorListDTO>().ReverseMap();
            CreateMap<AuthorCreateVM, AuthorCreateDTO>().ReverseMap();
            //CreateMap<List<AuthorCreateVM>, List<AppUser>>().ReverseMap();
            //CreateMap<AuthorCreateVM, AppUser>().ReverseMap();
            CreateMap<AppRoleCreateDTO, RoleCreateVM>().ReverseMap();
            CreateMap<AppRoleListDTO, RoleListVM>().ReverseMap();
            CreateMap<AppRoleUpdateDTO, RoleUpdateVM>().ReverseMap();
            CreateMap<UserRoleAssignDTO, UserRoleAssignVM>().ReverseMap();
            CreateMap<UserListDTO, UserListVM>().ReverseMap();
            CreateMap<AppUser, UserListVM>().ReverseMap();


            CreateMap<PostCreateDTO, PostCreateVM>().ReverseMap();
            CreateMap<PostUpdateDTO, PostCreateVM>().ReverseMap();
            CreateMap<PostListDTO, PostListVM>().ReverseMap();
            CreateMap<PostUpdateDTO, PostUpdateVM>().ReverseMap();

            //CreateMap<CategoryCreateVM, CategoryPost>().ReverseMap();








           
        }
    }
}
