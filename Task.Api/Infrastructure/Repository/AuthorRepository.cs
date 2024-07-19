using Application.Interface;
using Core.Model;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    
    public class AuthorRepository(AppDataContext context) : GenericRepository<Author>(context), IAuthorRepository
    {
    }
}
