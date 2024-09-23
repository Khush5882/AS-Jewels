using System;
using System.Collections.Generic;

namespace jeweller_app.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<CartProduct> CartItems { get; set; } = new List<CartProduct>();
    }

    public class CartProduct
    {
        public int Id { get; set; } // This might be necessary if you're tracking cart item IDs
        public int ProductId { get; set; } // Assuming this is for the product being added to the cart
        public string Email { get; set; } // User's email associated with the cart
        public decimal Price { get; set; } // Price of the product at the time of adding to cart
        public int Quantity { get; set; } // Quantity of the product in the cart
    }

}
