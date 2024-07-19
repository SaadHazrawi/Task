using Application.Common.Dtos.SubCategory;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ISubCategoreyServices
    {
       Task<SubCategory> Add(SubCategoryAddDTO subCategoryAdd);
        Task<List<SubCategoryResponseDTO>> GetByCategoreyId(int categoreyId);
    }
}
