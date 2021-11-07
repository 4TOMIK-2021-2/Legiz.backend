using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Legiz.Back_End.UserProfileBC.Resources
{
    public class SaveLawyerResource
    {
        [Required]
        [NotNull]
        [MaxLength(10)]
        public string Username { get; set; }
        
        [Required]
        [NotNull]
        [MaxLength(10)]
        public string Password { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string District { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string University { get; set; }

        [Required]
        [Range(1,5)]
        public int Specialization { get; set; }
        
        [Required]
        public int PriceLegalAdvice { get; set; }
        
        [Required]
        public int PriceCustomContract { get; set; }
    }
}