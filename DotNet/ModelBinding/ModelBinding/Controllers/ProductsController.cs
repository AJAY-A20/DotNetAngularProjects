using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    // Automatically handles model validation errors and infers binding sources
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Initialize the products list with some hardcoded data
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" },
            new Product { Id = 2, Name = "Smartphone", Price = 699.99m, Category = "Electronics" },
            new Product { Id = 3, Name = "Desk Chair", Price = 149.99m, Category = "Furniture" },
        };
        // Action method to get a product by its ID using route data
        // The {id:int} ensures that the route will match only if the ID is an integer
        [HttpGet("{id:int}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            // Find the first product in the list with the matching ID
            var product = products.FirstOrDefault(p => p.Id == id);
            // If the product is not found, return a 404 Not Found response with a custom message
            if (product == null)
            {
                return NotFound(new { Message = "Product not found." });
            }
            // If the product is found, return a 200 OK response with the product data
            return Ok(product);
        }
        // Action method to get products, optionally filtered by category using query string data
        // If no category is specified, all products are returned
        [HttpGet]
        public IActionResult GetProducts([FromQuery] string category)
        {
            // If category is null or empty, return all products; otherwise, filter by category
            var filteredProducts = string.IsNullOrEmpty(category)
                ? products
                : products.Where(p => p.Category == category).ToList();
            // Return the filtered products (or all products) with a 200 OK response
            return Ok(filteredProducts);
        }
        // Action method to create a new product using data from the request body
        // The [FromBody] attribute indicates that the product data will be parsed from the request body (usually JSON)
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            // Check if the model is valid (e.g., all required fields are provided and valid)
            if (!ModelState.IsValid)
            {
                // If the model is invalid, return a 400 Bad Request response with the validation errors
                return BadRequest(ModelState);
            }
            // Add the new product to the products list
            products.Add(product);
            // Return a 201 Created response with the URI of the newly created product and the product data
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        // Action method to update an existing product using route data for the ID and body data for the product details
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            // Check if the model is valid before processing the update
            if (!ModelState.IsValid)
            {
                // If the model is invalid, return a 400 Bad Request response with the validation errors
                return BadRequest(ModelState);
            }
            // Find the product in the list by ID
            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                // If the product is not found, return a 404 Not Found response
                return NotFound(new { Message = "Product not found." });
            }
            // Update the existing product's properties with the new values
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            // Return a 204 No Content response indicating that the update was successful
            return NoContent();
        }
        // Action method to delete a product by its ID using route data
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            // Find the product in the list by ID
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                // If the product is not found, return a 404 Not Found response
                return NotFound(new { Message = "Product not found." });
            }
            // Remove the product from the list
            products.Remove(product);
            // Return a 204 No Content response indicating that the deletion was successful
            return NoContent();
        }
        // Action method to get a product by its ID using a custom header
        [HttpGet("headers")]
        public IActionResult GetProductFromHeader([FromHeader(Name = "Product-Id")] int id)
        {
            // Find the product in the list by ID, using the value from the "Product-Id" header
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                // If the product is not found, return a 404 Not Found response
                return NotFound(new { Message = "Product not found." });
            }
            // Return the product with a 200 OK response
            return Ok(product);
        }
        // Action method to handle file uploads using form data
        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm] IFormFile file)
        {
            // Check if the file is valid (e.g., it is not null and has content)
            if (file == null || file.Length == 0)
            {
                // If the file is invalid, return a 400 Bad Request response with a custom message
                return BadRequest(new { Message = "Invalid file." });
            }
            // Process the file (this could involve saving it to the server, etc.)
            // Here, just a placeholder comment
            // Return a 200 OK response indicating that the file upload was successful
            return Ok(new { Message = "File uploaded successfully." });
        }

    }
}
