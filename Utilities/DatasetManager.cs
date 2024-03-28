using FakeApi.Models;
using Newtonsoft.Json;

namespace FakeApi.Utilities
{
    public class DatasetManager
    {
        private readonly string _datasetProducts = "Dataset/products.json";
        private readonly string _datasetCategories = "Dataset/categories.json";
        private IWebHostEnvironment _env;

        public DatasetManager(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<ProductModel> GetAllProducts()
        {
            var webRoot = _env.WebRootPath;
            var datasetPath = Path.Combine(webRoot, _datasetProducts);


            var jsonContent = File.ReadAllText(datasetPath);

            try
            {
                List<ProductModel> products = JsonConvert.DeserializeObject<List<ProductModel>>(jsonContent) ?? new List<ProductModel>();
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ProductModel? GetProductById (string id)
        {
            var products = GetAllProducts();
            var product = products.Where(m => m.Id == id).FirstOrDefault();
            return product;
        }

        public List<ProductModel> GetByCategory(string categoryId)
        {
            var products = GetAllProducts();
            var filteredProducts = products.Where(m => m.Category_Id == categoryId);
            return filteredProducts.ToList();
        }

        public List<CategoryModel> GetAllCategories()
        {
            var webRoot = _env.WebRootPath;
            var datasetPath = Path.Combine(webRoot, _datasetCategories);
            try
            {
                var jsonContent = File.ReadAllText(datasetPath);
                List<CategoryModel> categories = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonContent) ?? new List<CategoryModel>();
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public CategoryModel? GetCategoryById(int id)
        {
            var categories = GetAllCategories();
            var category = categories.Where(m => m.Id == id).FirstOrDefault();
            return category;
        }

        public CategoryModel? GetCategoryByName(string name)
        {
            var categories = GetAllCategories();
            var category = categories.Where(m => m.Name == name).FirstOrDefault();
            return category;
        }
    }
}
