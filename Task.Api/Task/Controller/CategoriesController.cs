using Application.Common.Dtos.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Task.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoreyServices _categoreyServices;
        public CategoriesController(ICategoreyServices categoreyServices)
        {
            _categoreyServices = categoreyServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetCatoreyWithSubcateogrey(int pageIndex, int pageSize)
        {
            var categoires = await _categoreyServices.GetAll(pageIndex, pageSize);
            return Ok(categoires);
        }
        [HttpPost]
        public async Task<IActionResult>AddCateogrey(CategoreyAddDto categoreyAdd)
        {
           var categorey= await _categoreyServices.Add(categoreyAdd);
            return Ok(categorey);
        }
    }
}
