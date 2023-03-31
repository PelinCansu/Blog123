using Blog123.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Domain.Repositories
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        Task<List<Category>> DeActiveCategories();
        Task<Category> GetByIdWithNoTracking(int id);
        Task<Category> GetByIdWithModified(int id);
    }
}
