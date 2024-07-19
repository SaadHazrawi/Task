using Application.Common;
using Application.Common.Dtos.Book;
using Core.common.filter;
using Core.Model;

namespace Services.IServices
{
    public interface IBookServices
    {
        Task<Pagination<BookResponseDto>> GetAll(int pageIndex, int pageSize);
        Task<List<BookResponseDto>> GetBooksByFilter(  BookFilterDto filters);
        Task<BookResponseDto> Get(int id);
        Task<Book> Add(BookAddDto request);
        Task Update(int id,BookUpdateDto request);
        Task Delete(int id);
        List<Book> GetBooksBySubcategoryStoreProc(int subcategoryId);
    }
}
