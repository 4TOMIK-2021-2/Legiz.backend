using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Legiz.Back_End.UserProfileBC.Resources
{
    public class SaveSubscriptionResource
    {
        [Required]
        public int Price { get; set; }
        
        [Required]
        [NotNull]
        public string Description { get; set; }
        
        [Required]
        [Range(1,2)]
        public int State { get; set; }
    }
}