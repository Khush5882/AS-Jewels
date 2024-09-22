using Microsoft.AspNetCore.Mvc;
using ASJewellers.Models;

namespace ASJewellers.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Check the credentials (this is where you'd query the database)
                if (model.Username == "admin" && model.Password == "password")
                {
                    // Redirect to home page or admin dashboard if credentials are correct
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }
    }
}

