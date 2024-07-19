using System.Text.Json.Serialization;

namespace Core.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<SubCategory> Subcategories { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
