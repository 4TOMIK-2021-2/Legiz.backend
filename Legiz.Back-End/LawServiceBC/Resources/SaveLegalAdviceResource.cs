using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Legiz.Back_End.LawServiceBC.Resources
{
    public class SaveLegalAdviceResource
    {
        [Required]
        [NotNull]
        public string Title { get; set; }
        
        [Required]
        [Range(1,2)]
        public int StatusLawService { get; set; }
        
        [Required]
        [NotNull]
        public string Description { get; set; }
        
        [Required]
        public int LawyerId { get; set; }
        
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int LegalDocumentId { get; set; }
    }
}