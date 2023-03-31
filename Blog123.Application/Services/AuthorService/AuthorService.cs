using AutoMapper;
using Blog123.Application.Models.DTOs.AuthorDTOs;
using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog123.Application.Services.AuthorService
{
    public class AuthorService:IAuthorService
    {
        IAuthorRepository _authorRepository;
        IMapper _mapper;
        //IBaseRepository<AppUser> _baseRepository;
        
        
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            this._authorRepository = authorRepository;
            this._mapper = mapper;
            //this._baseRepository = baseRepository;
        }


        public async Task<List<AuthorListDTO>> AllAuthors()
        {
            return _mapper.Map<List<AuthorListDTO>>(await _authorRepository.GetAll());
        }

        //public async Task<List<AppUser>> AllUsers()
        //{
        //  return await _baseRepository.GetAll();
        //}

        public async Task Create(AuthorCreateDTO authorCreateDTO)
        {
            var author = _mapper.Map<Author>(authorCreateDTO);
            await _authorRepository.Add(author);
        }

        public async Task Edit(AuthorUpdateDTO authorUpdateDTO)
        {
            Author author = _mapper.Map<Author>(authorUpdateDTO);
            await _authorRepository.Update(author);
        }

        public async Task<AuthorUpdateDTO> GetById(Guid id)
        {
            return _mapper.Map<AuthorUpdateDTO>(await _authorRepository.GetBy(x => x.Id == id));
        }

        public async Task<List<AuthorListDTO>> GetDefaults(Expression<Func<Author, bool>> expression)
        {
            var result = await _authorRepository.GetDefault(expression);
            var listAuthorResult = _mapper.Map<List<AuthorListDTO>>(result);
            return listAuthorResult;
        }

       

        public async Task<bool> IsAuthorExists(string authorUserName)
        {
           return  await _authorRepository.Any(x => x.UserName.Contains(authorUserName));
        }

       

        public async Task Remove(Guid id)
        {
            Author author = await _authorRepository.GetBy(x => x.Id == id);
            await _authorRepository.Delete(author);
        }
    }
}
