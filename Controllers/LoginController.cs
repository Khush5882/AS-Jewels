using jeweller_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace jeweller_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string HashPassword(string password)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            string hashedPassword = HashPassword(loginRequest.PasswordHash);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginRequest.Username && u.PasswordHash == hashedPassword);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok("Login successful!");
        }
    }
}
