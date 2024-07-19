using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos.Book
{
    public class BookAddDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }=DateTime.Now;
        public int AuthorId { get; set; }
        public int SubcategoryId { get; set; }
    }
}
