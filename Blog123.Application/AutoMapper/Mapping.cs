using AutoMapper;
using Blog123.Application.Models.DTOs.AppRoleDTOs;
using Blog123.Application.Models.DTOs.AppUserDTOs;
using Blog123.Application.Models.DTOs.AuthorDTOs;
using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Application.Models.DTOs.PostDTOs;
using Blog123.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();


            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryListDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<Author, AuthorCreateDTO>().ReverseMap();
            CreateMap<Author, AuthorUpdateDTO>().ReverseMap();
            CreateMap<Author, AuthorListDTO>().ReverseMap();



            CreateMap<Post, PostCreateDTO>().ReverseMap();
            CreateMap<Post, PostUpdateDTO>().ReverseMap();
            CreateMap<Post, PostListDTO>().ReverseMap();

            CreateMap<AppRole, AppRoleCreateDTO>().ReverseMap();
            CreateMap<AppRole, AppRoleListDTO>().ReverseMap();
            CreateMap<AppRole, AppRoleUpdateDTO>().ReverseMap();

            CreateMap<AppUser, UserListDTO>().ReverseMap();
            CreateMap<AppUser, UserRoleAssignDTO>().ReverseMap();
            CreateMap<AppRole, UserRoleAssignDTO>().ReverseMap();


            //CreateMap<CategoryPost, CategoryCreateDTO>().ReverseMap();
            //CreateMap<CategoryPost, CategoryListDTO>().ReverseMap();
   
           
           


        }
    }
}
