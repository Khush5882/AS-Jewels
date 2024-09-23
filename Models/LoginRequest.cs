namespace jeweller_app.Models  
{
    public class LoginRequest  
    {
        public string Username { get; set; } 
        public string PasswordHash { get; set; }
        public string Email { get; internal set; }
    }
}
