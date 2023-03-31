using AutoMapper;
using Blog123.Application.Models.DTOs.PostDTOs;
using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Services.PostService
{
    public class PostService: IPostService
    {
        IPostRepository _postRepository;
        IMapper _mapper;
        ICategoryPostRepository _categoryPostRepository;
        ICategoryRepository _categoryRepository;

        public PostService(IPostRepository postRepository, IMapper mapper, ICategoryPostRepository categoryPostRepository, ICategoryRepository categoryRepository)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
            this._categoryPostRepository = categoryPostRepository;
            this._categoryRepository = categoryRepository;
        }

        public async Task<List<PostListDTO>> AllPosts()
        {
          
            return  _mapper.Map<List<PostListDTO>>(await _postRepository.GetAll());

        }

  
        public async Task Create(PostCreateDTO postCreateDTO)
        {
            Post post = _mapper.Map<Post>(postCreateDTO);
            await _postRepository.Add(post);
        }

        public async Task Edit(PostUpdateDTO postUpdateDTO)
        {
            Post post = _mapper.Map<Post>(postUpdateDTO);
            await _postRepository.Update(post);
        }

        public async Task<PostUpdateDTO> GetById(Guid id)
        {
            return _mapper.Map<PostUpdateDTO>(await _postRepository.GetBy(x => x.Id == id));
        }

        public async Task<List<PostListDTO>> GetDefaults(Expression<Func<Post, bool>> expression)
        {
            var result = await _postRepository.GetDefault(expression);
            var listPostResult = _mapper.Map<List<PostListDTO>>(result);
            return listPostResult;
        }

		/// <summary>
		/// To get categories with post
		/// </summary>
		/// <returns></returns>
		public async Task<List<PostListDTO>> GetPostsWithCategories(string userName)
        {
          return _mapper.Map<List<PostListDTO>>(await  _postRepository.GetPostsWithCategories(userName));
        }

       

        public async Task<bool> IsPostExists(string postTitle)
        {
            return await _postRepository.Any(x => x.Title.Contains(postTitle));
        }

        public async Task Remove(Guid id)
        {
            Post post = await _postRepository.GetBy(x => x.Id == id);
            await _postRepository.Delete(post);
        }

        /// <summary>
        /// To add post with categories
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task AddToCategory(int categoryId, Guid postId)
        {
            var category = await _categoryRepository.GetBy(x => x.Id == categoryId);
            var post = await _postRepository.GetBy(x => x.Id == postId);

            var categoryPost = new CategoryPost
            {
                Post = post,
                Category = category

            };

           await _categoryPostRepository.Add(categoryPost);
        }

        /// <summary>
        /// To get Username of author with post
        /// </summary>
        /// <returns></returns>
		public async Task<List<PostListDTO>> GetPostsWithAuthors()
		{
			return _mapper.Map<List<PostListDTO>>(await _postRepository.GetPostsWithAuthors());

		}

	}
}
