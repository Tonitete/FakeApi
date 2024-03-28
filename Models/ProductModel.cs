namespace FakeApi.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Images { get; set; }
        public string Category_Id { get; set; }

        public ProductModel() 
        {
            Id = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Price = 0;
            Images = string.Empty;
            Category_Id = string.Empty;
        }
    }
}
