using Application.Common.Dtos.Author;
using Application.Interface.UnitOfWork;
using AutoMapper;
using Core.common;
using Core.Model;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Author> Add(AuthorAddDto authorAdd)
        {
            if(authorAdd is null)
            {
                throw new APIException(System.Net.HttpStatusCode.BadRequest,"Invlaid add data");
            }
            var author = _mapper.Map<Author>(authorAdd);
            await _unitOfWork.Author.AddAsync(author);
           await _unitOfWork.SaveChangesAsync();
            return author;
        }
    }
}
