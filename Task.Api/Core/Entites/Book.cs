using System.Text.Json.Serialization;

namespace Core.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }  
        public int SubcategoryId { get; set; }
        public SubCategory Subcategory { get; set; } 
        public bool IsDelete { get; set; }=false;
    }
}
