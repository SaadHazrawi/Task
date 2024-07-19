using Application.Common;
using Application.Common.Dtos.Book;
using Application.Interface.UnitOfWork;
using AutoMapper;
using Core.common;
using Core.common.filter;
using Core.Model;
using Services.IServices;
using System.Net;

namespace Services.Services
{
    public class BookServices : IBookServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<Book> GetBooksBySubcategoryStoreProc(int subcategoryId)
        {
            var books = _unitOfWork.Book.GetBooksBySubcategory(subcategoryId).ToList();
            if (books is null)
            {
                throw new APIException(HttpStatusCode.NotFound, $"Books Not Found With subcategoryId:{subcategoryId}");
            }
            return books;
        }
        public async Task<Book> Add(BookAddDto request)
        {
            if (request == null)
            {
                throw new APIException(HttpStatusCode.BadRequest, "Book information cannot be null.");
            }
            var subCategory = await _unitOfWork.SubCategory.FirstOrDefaultAsync(x => x.Id == request.SubcategoryId);
            var author = await _unitOfWork.Author.FirstOrDefaultAsync(x => x.Id == request.AuthorId);

            if (subCategory is null || author is null)
            {
                throw new APIException(HttpStatusCode.NotFound, "Invalid subcategory or author ID.");
            }
            var book = _mapper.Map<Book>(request);
            await _unitOfWork.Book.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
            return book;
        }
        public async Task<BookResponseDto> Get(int id)
        {
            var book = await _unitOfWork.Book.GetByIdAsync(id, true,
                b => b.Author,
                b => b.Subcategory);

            if (book == null)
            {
                throw new APIException(HttpStatusCode.NotFound, $"Book with ID {id} not found.");
            }

            return _mapper.Map<BookResponseDto>(book);
        }

        public async Task<Pagination<BookResponseDto>> GetAll(int pageIndex, int pageSize)
        {
            if (pageSize <= 0 || pageSize > 50)
            {
                pageSize = 50;
            }
            var books = await _unitOfWork.Book.ToPagination(pageIndex, pageSize,
                asNoTracking: true,
                where: null,
                orderBy: b => b.PublishDate,
                orderByDescending: true,
                includes: [ b => b.Author,
                     b => b.Subcategory]);
            if (books is null || books.Items.Count == 0)
            {
                throw new APIException(HttpStatusCode.NotFound, "No books found.");
            }
            var booksDtoPagination = new Pagination<BookResponseDto>
            {
                PageIndex = books.PageIndex,
                PageSize = books.PageSize,
                TotalItemsCount = books.TotalItemsCount,
                Items = _mapper.Map<List<BookResponseDto>>(books.Items)
            };

            return booksDtoPagination;
        }
        public async Task Delete(int id)
        {
            var book = await _unitOfWork.Book.GetByIdAsync(id, true, null);

            if (book == null)
            {
                throw new APIException(HttpStatusCode.NotFound, $"Book with ID {id} not found.");
            }
            book.IsDelete = true;
            _unitOfWork.Book.Update(book);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<BookResponseDto>> GetBooksByFilter(BookFilterDto filters)
        {
            var query = _unitOfWork.Book.Query();
            if (filters != null)
            {
                if (!string.IsNullOrEmpty(filters.Name))
                {
                    query = query.Where(b => b.Name.Contains(filters.Name));
                }

                if (filters.PublishDateFrom.HasValue)
                {
                    query = query.Where(b => b.PublishDate >= filters.PublishDateFrom.Value);
                }

                if (filters.PublishDateTo.HasValue)
                {
                    query = query.Where(b => b.PublishDate <= filters.PublishDateTo.Value);
                }

                if (filters.SubcategoryId.HasValue)
                {
                    query = query.Where(b => b.SubcategoryId == filters.SubcategoryId.Value);
                }

                if (filters.AuthorId.HasValue)
                {
                    query = query.Where(b => b.AuthorId == filters.AuthorId.Value);
                }
            }

            var booksFilter = query.ToList();
            if (booksFilter is null || booksFilter.Count == 0)
            {
                throw new APIException(HttpStatusCode.NotFound, "No books found.");
            }


            return _mapper.Map<List<BookResponseDto>>(booksFilter);
        }

        public async Task Update(int id, BookUpdateDto request)
        {
            var book = await _unitOfWork.Book.GetByIdAsync(id, true, null);

            if (book == null || request == null)
            {
                throw new APIException(HttpStatusCode.NotFound, "Invalid data. Please try again.");
            }

            _mapper.Map(request, book);
            _unitOfWork.Book.Update(book);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
