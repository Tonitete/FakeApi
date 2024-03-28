using FakeApi.Models;
using FakeApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FakeApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FakeApiController : ControllerBase
    {
        private IWebHostEnvironment _env;
        public FakeApiController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // GET /FakeApi/GetProducts
        [HttpGet("getproducts")]
        public ActionResult GetProducts()
        {
            var dm = new DatasetManager(_env);
            var products = dm.GetAllProducts();
            
            return new JsonResult(products);
        }

        // GET /FakeApi/GetProducts/{id}
        [HttpGet("getproducts/{id}")]
        public ActionResult GetProductById(string id)
        {
            var dm = new DatasetManager(_env);
            var product = dm.GetProductById(id);
            return new JsonResult(product);
        }

        // GET /FakeApi/GetProductCategory/{category_id}
        [HttpGet("getproductcategory/{category}")]
        public ActionResult GetProductByCategory(int category)
        {
            var dm = new DatasetManager(_env);
            var products = dm.GetByCategory(category.ToString());
            return new JsonResult(products);
        }

        // GET /FakeApi/GetCategories
        [HttpGet("getcategories")]
        public ActionResult GetCategories()
        {
            var dm = new DatasetManager(_env);
            var categories = dm.GetAllCategories();
            return new JsonResult(categories);
        }

        // GET /FakeApi/GetCategories/Name/{name}
        [HttpGet("getcategories/name/{name}")]
        public ActionResult GetCategoriesByName(string name)
        {
            var dm = new DatasetManager(_env);
            var categories = dm.GetCategoryByName(name);
            return new JsonResult(categories);
        }

        // GET /FakeApi/GetCategories/{id}
        [HttpGet("getcategories/{id}")]
        public ActionResult GetCategoryById(int id)
        {
            var dm = new DatasetManager(_env);
            var category = dm.GetCategoryById(id);
            return new JsonResult(category);
        }

        // POST /FakeApi/AddProduct
        [HttpPost("addproduct")]
        public ActionResult PostProduct([FromBody] ProductModel value)
        {
            value.Id = Guid.NewGuid().ToString();
            return new JsonResult(value);
        }

        // POST /FakeApi/AddCategory
        [HttpPost("addcategory")]
        public ActionResult PostCategory([FromBody] CategoryModel value)
        {
            var dm = new DatasetManager(_env);
            var maxId = dm.GetAllCategories().Max(m => m.Id);
            value.Id = maxId + 1;
            return new JsonResult(value);
        }

        // DELETE /FakeApi/DeleteProduct/{id}
        [HttpDelete("deleteproduct/{id}")]
        public ActionResult DeleteProduct(string id)
        {
            var dm = new DatasetManager(_env);
            var product = dm.GetProductById(id);
            if (product != null)
            {
                var response = new
                {
                    success = true,
                    deleted = id,
                };
                return new JsonResult(response);
            }
            else
            {
                var response = new
                {
                    success = false,
                    reason = "Item not found."
                };
                return new JsonResult(response);
            }
        }

        // DELETE /FakeApi/DeleteCategory/{id}
        [HttpDelete("deletecategory/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            var dm = new DatasetManager(_env);
            var category = dm.GetCategoryById(id);
            if (category != null)
            {
                var response = new
                {
                    success = true,
                    deleted = id,
                };
                return new JsonResult(response);
            }
            else
            {
                var response = new
                {
                    success = false,
                    reason = "Item not found."
                };
                return new JsonResult(response);
            }
        }

    }
}
