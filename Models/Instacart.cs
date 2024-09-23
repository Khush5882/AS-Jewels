using System.Collections.Generic;
using jeweller_app.Models;

public class InstaCart
{
    public int Id { get; set; }
    public string Email { get; set; }
    public List<CartList> Lists { get; set; } = new List<CartList>();
}

public class CartList
{
    public string Name { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
}

