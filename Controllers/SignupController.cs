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
    public class SignupController : ControllerBase  
    {
        private readonly ApplicationDbContext _context;  

        public SignupController(ApplicationDbContext context) 
        {
            _context = context;
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())  
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)); 
                StringBuilder builder = new StringBuilder();  
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));  
                }
                return builder.ToString();  
            }
        }
       
        [HttpPost]
        public async Task<IActionResult> Signup([FromBody] User user)
        {
            if (!ModelState.IsValid)  
            {
                return BadRequest("Invalid data.");  
            }

            
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username || u.Email == user.Email);

            if (existingUser != null)
            {
                return BadRequest("Username or Email already exists."); 
            }

            
            user.PasswordHash = HashPassword(user.PasswordHash);

            
            _context.Users.Add(user);
            await _context.SaveChangesAsync(); 

            return Ok("Signup successful!");  
        }
    }
}
