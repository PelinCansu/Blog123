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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(Blog123DbContext blog123DbContext) : base(blog123DbContext)
        {
            this._dbContext = blog123DbContext;
            _authorTable = _dbContext.Authors;
        }

        Blog123DbContext _dbContext;
        DbSet<Author> _authorTable;
    }
}
