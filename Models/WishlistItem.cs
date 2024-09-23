namespace jeweller_app.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  // Product being added to wishlist
        public int UserId { get; set; }  // User ID who added the product to wishlist

        // Navigation properties
        public Product Product { get; set; }
        public User User { get; set; }
    }
}

