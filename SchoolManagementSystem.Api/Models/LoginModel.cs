using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Api.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; } = "superadmin@gmail.com";
        [Required]
        public string Password { get; set; } = "Softech@123";
    }

    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; } = new object();
    }

    public class LoginResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime NotBefore { get; set; }
        public DateTime Expiration { get; set; }
        public string Role { get; set; }
        public bool IsModelAccess { get; set; }
        public string UserId { get; set; }
        public string Post { get; set; }
        public string WardName { get; set; }
    }
}
