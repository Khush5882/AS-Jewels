using Microsoft.AspNetCore.Mvc;
using ASJewellers.Models;

namespace ASJewellers.Controllers
{
    public class SignupController : Controller
    {
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(SignupModel model)
        {
            if (ModelState.IsValid)
            {
                // Here you'd save the signup details to the database
                // Save model details to the database
                return RedirectToAction("Login", "Login");
            }
            return View(model);
        }
    }
}

