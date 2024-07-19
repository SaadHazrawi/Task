using Application.Common.Dtos.SubCategory;
using Application.Interface.UnitOfWork;
using AutoMapper;
using Core.common;
using Core.Model;
using Services.IServices;

namespace Services.Services
{
    public class SubCategoreyServices : ISubCategoreyServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubCategoreyServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SubCategory> Add(SubCategoryAddDTO subCategoryAdd)
        {
            if (subCategoryAdd is null)
            {
                throw new APIException(System.Net.HttpStatusCode.BadRequest, "Invliad Date To Add");
            }
            var catogrey = await _unitOfWork.Category.GetByIdAsync(subCategoryAdd.CategoryId, true, null);
            if (catogrey is null)
            {
                throw new APIException(System.Net.HttpStatusCode.NotFound, "Not Found Catgorey");
            }
            var catgorey = _mapper.Map<SubCategory>(subCategoryAdd);
            await _unitOfWork.SubCategory.AddAsync(catgorey);
            await _unitOfWork.SaveChangesAsync();
            return catgorey;
        }
        public async Task<List<SubCategoryResponseDTO>> GetByCategoreyId(int categoreyId)
        {
            var subCatgoreis = await _unitOfWork.SubCategory.GetAllAsync(
                where: i => i.CategoryId == categoreyId);
            return _mapper.Map<List<SubCategoryResponseDTO>>(subCatgoreis);

        }
    }
}
