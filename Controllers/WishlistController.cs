using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jeweller_app.Models;
using System.Linq;
using System.Threading.Tasks;

namespace jeweller_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WishlistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add item to wishlist
        [HttpPost("add")]
        public async Task<IActionResult> AddToWishlist([FromBody] WishlistItem wishlistItem)
        {
            if (wishlistItem == null)
            {
                return BadRequest("Invalid wishlist item.");
            }

            await _context.WishlistItems.AddAsync(wishlistItem);
            await _context.SaveChangesAsync();

            return Ok("Item added to wishlist.");
        }

        // Get wishlist items for a user
        [HttpGet("get")]
        public async Task<IActionResult> GetWishlistItems(int userId)
        {
            var wishlistItems = await _context.WishlistItems
                .Include(w => w.Product)
                .Where(w => w.UserId == userId)
                .ToListAsync();

            if (wishlistItems == null || wishlistItems.Count == 0)
            {
                return NotFound("Wishlist is empty.");
            }

            return Ok(wishlistItems);
        }
    }
}
