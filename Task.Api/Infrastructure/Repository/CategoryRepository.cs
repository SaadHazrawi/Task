using Application.Interface;
using Core.Model;
using Infrastructure.Data;

namespace Infrastructure.Repository
{ 
    public class CategoryRepository(AppDataContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
    }
}
