using Microsoft.AspNetCore.Mvc;
using ASJewellers.Models;
using System.Linq;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult ManageProducts()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ManageProducts");
        }
        return View("ManageProducts");
    }

    [HttpPost]
    public IActionResult RemoveProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        return RedirectToAction("ManageProducts");
    }
}

