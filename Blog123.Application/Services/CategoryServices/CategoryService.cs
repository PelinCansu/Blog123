using AutoMapper;
using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        ICategoryRepository _categoryRepository;
        IMapper _mapper;

        public async Task Create(CategoryCreateDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            await _categoryRepository.Add(category);

        }
        //author yani yazarın entity,mapping,Repo ve Service nesnelerini oluştursunlar(kategoriyi bitirenler)
        public async Task Edit(CategoryUpdateDTO categoryDTO)
        {
            //Bunun yerine mapper ile tek satır kodda işlemi bitiriyoruz.

            //Category c = new Category();
            //c.Name=categoryDTO.Name
            Category category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(category);
        }

        public async Task Remove(int id)
        {
            Category category = await _categoryRepository.GetBy(x => x.Id == id);
            await _categoryRepository.Delete(category);
        }

        public async Task<List<CategoryListDTO>> AllCategories()
        {
            return _mapper.Map<List<CategoryListDTO>>(await _categoryRepository.GetAll());
        }

        public async Task<CategoryUpdateDTO> GetById(int id)
        {
            return _mapper.Map<CategoryUpdateDTO>(await _categoryRepository.GetBy(x => x.Id == id));
        }

        public async Task<bool> IsCategoryExists(string categoryName)
        {
            return await _categoryRepository.Any(x => x.Name.Contains(categoryName));
        }

        public async Task<List<CategoryListDTO>> GetDefaults(Expression<Func<Category, bool>> expression)
        {

            var result = await _categoryRepository.GetDefault(expression);
            var listCategoryResult = _mapper.Map<List<Category>, List<CategoryListDTO>>(result);
            return listCategoryResult;
        }

        public async Task<CategoryCreateDTO> GetByIdWithNoTracking(int id)

        {
            return _mapper.Map<CategoryCreateDTO>(await _categoryRepository.GetByIdWithNoTracking(id));
        }

        public async Task<CategoryCreateDTO> GetByIdWithModified(int id)
        {
            return  _mapper.Map<CategoryCreateDTO>(await _categoryRepository.GetByIdWithModified(id));

        }
    }
}
