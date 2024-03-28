namespace FakeApi.Models
{
    public class CategoryModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Image { get; set; }
        public CategoryModel()
        {
            Name = string.Empty;
            Image = string.Empty;
        }
    }
}
