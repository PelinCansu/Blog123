using Blog123.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Domain.Repositories
{
    public interface IPostRepository:IBaseRepository<Post>
    {
        Task<List<Post>> GetPostsWithCategories(string userName);
        Task<List<Post>> GetPostsWithAuthors();
    }


}
