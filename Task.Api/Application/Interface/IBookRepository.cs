using Application.Interface.GenericRepository;
using Core.Model;

namespace Application.Interface
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetBooksBySubcategory(int subcategoryId);
    }

}

