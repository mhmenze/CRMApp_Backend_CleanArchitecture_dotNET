namespace CRMApp.WEB.Models
{
    public class LoginModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class AuthenticatedResponse
    {
        public string? Token { get; set; }
    }
}
