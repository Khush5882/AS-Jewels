using jeweller_app.Models;

public class CartItemModel
{
    public int Id { get; set; } // Unique identifier for the cart item
    public int ProductId { get; set; } // Product ID
    public string Email { get; set; } // User email
    public decimal Price { get; set; } // Price at the time of adding to cart
    public int Quantity { get; set; } // Quantity of the product

    // Navigation property for related Product
    public required Product Product { get; set; }
}
