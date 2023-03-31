using Blog123.Application.Models.DTOs.AppRoleDTOs;
using Blog123.Application.Models.DTOs.AuthorDTOs;
using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Services.AuthorService
{
    public interface IAuthorService
    {
        Task Create(AuthorCreateDTO authorCreateDTO);
        Task Edit(AuthorUpdateDTO authorUpdateDTO);
        Task Remove(Guid id);

        Task<List<AuthorListDTO>> GetDefaults(Expression<Func<Author, bool>> expression);
        Task<List<AuthorListDTO>> AllAuthors();
        //Task<List<AppUser>> AllUsers();
        Task<AuthorUpdateDTO> GetById(Guid id);
        Task<bool> IsAuthorExists(string authorUserName);

    }
}
