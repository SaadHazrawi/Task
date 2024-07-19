using Application.Common.Dtos.SubCategory;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Task.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoreyServices _subCategoreyServices;

        public SubCategoriesController(ISubCategoreyServices subCategoreyServices)
        {
            _subCategoreyServices = subCategoreyServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddSubCatorey(SubCategoryAddDTO subCategoreyAdd)
        {
            var subCateogrey = await _subCategoreyServices.Add(subCategoreyAdd);
            return Ok(subCateogrey);
        }
        [HttpGet("{catgoreyId}")]
        public async Task<IActionResult> GetByCategoreyId(int catgoreyId)
        {
            var catgorey = await _subCategoreyServices.GetByCategoreyId(catgoreyId);
            return Ok(catgorey);
        }
    }
}
