using Application.Common;
using Application.Common.Dtos.Category;
using Core.Model;

namespace Services.IServices
{
    public interface ICategoreyServices
    {
        Task<Pagination<CategoryResponseDTO>> GetAll(int pageIndex, int pageSize);
        Task<Category> Add(CategoreyAddDto categoreyAdd);
    }
}
