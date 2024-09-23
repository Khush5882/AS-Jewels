using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jeweller_app.Models;
using System.Threading.Tasks;

namespace jeweller_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Update cart item quantity
        [HttpPost("update")]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartModel updateCartModel)
        {
            var cartItem = await _context.CartItems.FindAsync(updateCartModel.CartItemId);

            if (cartItem == null)
            {
                return NotFound("Cart item not found.");
            }

            cartItem.Quantity = updateCartModel.Quantity;
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();

            return Ok("Cart updated successfully.");
        }
    }
}

