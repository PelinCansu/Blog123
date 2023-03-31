using Blog123.Application.Models.DTOs.CategoryDTOs;
using Blog123.Application.Models.DTOs.PostDTOs;
using Blog123.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Services.PostService
{
    public interface IPostService
    {
        Task Create(PostCreateDTO postCreateDTO);
        Task Edit(PostUpdateDTO postUpdateDTO);
        Task Remove(Guid id);

        Task<List<PostListDTO>> GetDefaults(Expression<Func<Post, bool>> expression);
        Task<List<PostListDTO>> AllPosts();
        Task<PostUpdateDTO> GetById(Guid id);
        Task<List<PostListDTO>> GetPostsWithCategories(string userName);

        Task AddToCategory(int categoryId, Guid postId);
        Task<bool> IsPostExists(string postTitle);
        Task<List<PostListDTO>> GetPostsWithAuthors();

	}
}
