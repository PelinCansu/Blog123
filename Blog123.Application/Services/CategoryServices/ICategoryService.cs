using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task Create(CategoryCreateDTO categoryDTO);
        Task Edit(CategoryUpdateDTO categoryDTO);
        Task Remove(int id);

        Task<List<CategoryListDTO>> GetDefaults(Expression<Func<Category, bool>> expression);
        Task<List<CategoryListDTO>> AllCategories();
        Task<CategoryUpdateDTO> GetById(int id);
        Task<bool> IsCategoryExists(string categoryName);
        Task<CategoryCreateDTO> GetByIdWithNoTracking(int id);

        Task<CategoryCreateDTO> GetByIdWithModified(int id);
    }
}
