namespace jeweller_app.Models
{
    public class UpdateCartModel
    {
        public int CartItemId { get; set; } // ID of the cart item to update
        public int Quantity { get; set; } // New quantity for the cart item
    }
}
