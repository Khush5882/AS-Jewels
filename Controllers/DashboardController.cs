using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jeweller_app.Models;
using System.Threading.Tasks;

namespace jeweller_app.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Calculate total sales, orders, and products in stock
            decimal totalSales = await _context.Orders.SumAsync(o => o.TotalAmount);
            int totalOrders = await _context.Orders.CountAsync();
            int totalProducts = await _context.Products.SumAsync(p => (int)p.Stock);

            // Pass the data to the view using a model
            var metrics = new DashboardMetrics
            {
                TotalSales = totalSales,
                TotalOrders = totalOrders,
                TotalProducts = totalProducts
            };

            return View(metrics);
        }
    }
}
