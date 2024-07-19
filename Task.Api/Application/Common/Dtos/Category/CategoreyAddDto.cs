using System.ComponentModel.DataAnnotations;

namespace Application.Common.Dtos.Category
{
    public class CategoreyAddDto
    {
        [MinLength(3)]
        public string CategoryName { get; set; }
    }
}
