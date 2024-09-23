using Microsoft.AspNetCore.Mvc;
using jeweller_app.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace jeweller_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItem([FromBody] Product productModel)
        {
            var productExists = await _context.Products.FirstOrDefaultAsync(p => p.Name == productModel.Name);
            if (productExists != null)
            {
                return BadRequest(new { message = "Item already exists!" });
            }

            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Item created successfully!" });
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateItem([FromBody] Product productModel)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productModel.Id);
            if (product == null)
            {
                return NotFound(new { message = "Item not found!" });
            }

            product.Name = productModel.Name;
            product.Price = productModel.Price;
            product.Description = productModel.Description;
            product.CountInStock = productModel.CountInStock;
            product.Category = productModel.Category;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Item updated successfully!" });
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteItem([FromBody] int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Item not found!" });
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Item deleted successfully!" });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllItems()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}

