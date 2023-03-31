using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Repositories;
using Blog123.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.ConcreteRepositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly Blog123DbContext _dbContext;
        protected DbSet<Category> _categoryTable;
      
        

        public CategoryRepository(Blog123DbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._categoryTable = _dbContext.Categories;

           
          
        }

        public async Task<List<Category>> DeActiveCategories()
        {
            return await this.GetDefault(x => x.Status == Domain.Enums.Status.DeActive);
        }

        public  async Task<Category> GetByIdWithNoTracking(int id)

        {
         
            return await _categoryTable.AsNoTracking().Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<Category> GetByIdWithModified(int id)


        {
           Category category= await _categoryTable.Where(x => x.Id == id).FirstOrDefaultAsync();

            _dbContext.Entry<Category>(category).State = EntityState.Modified;
            return category;
        }


    }
}
