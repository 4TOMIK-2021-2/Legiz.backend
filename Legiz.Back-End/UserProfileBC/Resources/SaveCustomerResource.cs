using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Legiz.Back_End.UserProfileBC.Resources
{
    public class SaveCustomerResource
    {
        [Required]
        [NotNull]
        [MaxLength(10)]
        public string Username { get; set; }
        
        [Required]
        [NotNull]
        public string Password { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(9)]
        public string Phone { get; set; }
        
        [Required]
        [NotNull]
        public string CustomerName { get; set; }
        
        [Required]
        [NotNull]
        public string CustomerLastName { get; set; }
    }
}