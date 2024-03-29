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

        /// <summary>
        /// Retrieves all products from the dataset.
        /// </summary>
        /// <returns>A list of ProductModel objects representing the products.</returns>
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

        /// <summary>
        /// Retrieves a product model from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product model with the specified ID, or null if no product is found.</returns>
        public ProductModel? GetProductById(string id)
        {
            var products = GetAllProducts();
            var product = products.Where(m => m.Id == id).FirstOrDefault();
            return product;
        }

        /// <summary>
        /// Retrieves a list of ProductModel objects filtered by the specified category ID.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter by.</param>
        /// <returns>A list of ProductModel objects that belong to the specified category.</returns>
        public List<ProductModel> GetByCategory(string categoryId)
        {
            var products = GetAllProducts();
            var filteredProducts = products.Where(m => m.Category_Id == categoryId);
            return filteredProducts.ToList();
        }


        /// <summary>
        /// Retrieves all categories from the dataset file.
        /// </summary>
        /// <returns>A list of CategoryModel objects representing the categories.</returns>
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

        /// <summary>
        /// Retrieves a CategoryModel object from the database based on the provided ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>The CategoryModel object with the specified ID, or null if no category is found.</returns>
        public CategoryModel? GetCategoryById(int id)
        {
            var categories = GetAllCategories();
            var category = categories.Where(m => m.Id == id).FirstOrDefault();
            return category;
        }

        /// <summary>
        /// Retrieves a CategoryModel object from the list of all categories based on the provided name.
        /// </summary>
        /// <param name="name">The name of the category to retrieve.</param>
        /// <returns>The CategoryModel object with the specified name, or null if no category with that name exists.</returns>
        public CategoryModel? GetCategoryByName(string name)
        {
            var categories = GetAllCategories();
            var category = categories.Where(m => m.Name == name).FirstOrDefault();
            return category;
        }
    }
}
