using System;
using System.Collections.Generic;
using jeweller_app.Models;

public class SoldItem
{
    public int Id { get; set; }
    public string Email { get; set; }
    public List<SoldProduct> Items { get; set; } = new List<SoldProduct>();
}

public class SoldProduct
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public required Product Product { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Category { get; set; }
    public decimal Discount { get; set; } = 0;
    public bool Sold { get; set; } = false;
    public string Payment { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}

