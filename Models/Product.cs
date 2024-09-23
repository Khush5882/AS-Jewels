using System;
using System.ComponentModel.DataAnnotations;

namespace jeweller_app.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public string Image { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock count cannot be negative")]
        public int CountInStock { get; set; } // Stock count for the product

        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100")]
        public decimal Discount { get; set; } = 0; // Discount percentage

        public decimal NormalPrice { get; set; } // Original price of the product

        public DateTime? DiscountStart { get; set; } // Start date of the discount period

        public DateTime? DiscountEnd { get; set; } // End date of the discount period

        public bool Show { get; set; } = true; // Whether to display the product
        public object Stock { get; internal set; }

        // Optional method to calculate the effective price after applying the discount
        public decimal GetDiscountedPrice()
        {
            if (Discount > 0 && Discount <= 100)
            {
                return Price * (1 - (Discount / 100));
            }
            return Price;
        }
    }
}
