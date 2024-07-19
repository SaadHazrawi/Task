using Application.Interface;
using Core.Model;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    
    public class SubCategoryRepository(AppDataContext context) : GenericRepository<SubCategory>(context), ISubCategoryRepository
    {
    }
}
