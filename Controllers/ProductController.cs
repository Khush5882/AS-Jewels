using Microsoft.AspNetCore.Mvc;
using ASJewellers.Models;
using System.Linq;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult ProductList()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    public IActionResult ProductDetails(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
}

