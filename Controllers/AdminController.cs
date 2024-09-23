using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jeweller_app.Models;
using System.Threading.Tasks;

namespace jeweller_app.Controllers
{
    [ApiController]
    [Route("api/[Admin]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok("Product added successfully.");
        }

        [HttpPut("updateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            product.Stock = updatedProduct.Stock;

            await _context.SaveChangesAsync();
            return Ok("Product updated successfully.");
        }

        [HttpDelete("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product deleted successfully.");
        }

        [HttpGet("viewOrders")]
        public async Task<IActionResult> ViewOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("viewCustomers")]
        public async Task<IActionResult> ViewCustomers()
        {
            var customers = await _context.Users.ToListAsync();
            return Ok(customers);
        }
    }
}
