using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Repositories;
using Blog123.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.ConcreteRepositories
{
    public class CategoryPostRepository : BaseRepository<CategoryPost>, ICategoryPostRepository
    {
        Blog123DbContext _dbContext;
        DbSet<CategoryPost> _categoryPostTable;

        public CategoryPostRepository(Blog123DbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._categoryPostTable = _dbContext.CategoryPost;
        }
    }
}
