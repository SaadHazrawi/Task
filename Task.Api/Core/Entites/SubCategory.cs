using System.Text.Json.Serialization;

namespace Core.Model
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Book> Books { get; set; }  
        public bool IsDelete { get; set; } = false;
    }
}
