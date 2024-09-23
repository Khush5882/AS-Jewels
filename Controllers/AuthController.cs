using Microsoft.AspNetCore.Mvc;
using jeweller_app.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace jeweller_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] User userModel)
        {
            var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == userModel.Email);
            if (userExists != null)
            {
                return BadRequest(new { message = "User already exists!" });
            }

            userModel.PasswordHash = HashPassword(userModel.PasswordHash); // Hash the password

            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User created successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email);
            if (user == null || !VerifyPassword(loginModel.PasswordHash, user.PasswordHash))
            {
                return BadRequest(new { message = "Invalid email or password!" });
            }

            return Ok(new { message = "Login successful!", user = user });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Logic to handle logout (clear session/cookie if implemented)
            return Ok(new { message = "Logout successful!" });
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            return HashPassword(enteredPassword) == storedPasswordHash;
        }
    }
}
