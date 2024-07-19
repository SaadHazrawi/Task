using Application.Interface;
using Core.Model;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repository
{
    public class BookRepository(AppDataContext context) : GenericRepository<Book>(context), IBookRepository
    {
        public IEnumerable<Book> GetBooksBySubcategory(int subcategoryId)
        {
            var subcategoryIdParameter = new SqlParameter("@SubcategoryId", subcategoryId);
            var books = context.Books.FromSql($"EXEC GetBooksBySubcategory {subcategoryIdParameter}").IgnoreQueryFilters().AsEnumerable();
            return books;
        }

    }
}