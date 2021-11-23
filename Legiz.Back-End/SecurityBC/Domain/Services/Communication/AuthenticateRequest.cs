using System.ComponentModel.DataAnnotations;

namespace Legiz.Back_End.SecurityBC.Domain.Services.Communication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}