using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Repositories;
using Blog123.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Infrastructure.ConcreteRepositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly Blog123DbContext _dbContext;
        protected DbSet<Post> _postTable;
       

        public PostRepository(Blog123DbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._postTable = _dbContext.Posts;
          
        }

		public async Task<List<Post>> GetPostsWithAuthors()
		{
			return await _dbContext.Posts.Include(x=>x.Author).ThenInclude(x=>x.User).Where(x=>x.Status==Domain.Enums.Status.Active).ToListAsync();
		}

		public async Task<List<Post>> GetPostsWithCategories(string userName)
        {
            return await _dbContext.Posts.Include(x => x.Categories).Where(x => x.Author.UserName == userName).ToListAsync();
        }


    }
}
