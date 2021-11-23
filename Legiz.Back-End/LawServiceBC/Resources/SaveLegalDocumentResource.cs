using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Legiz.Back_End.LawServiceBC.Resources
{
    public class SaveLegalDocumentResource
    {
        [Required]
        [NotNull]
        public string DocumentTitle { get; set; }
        
        [Required]
        [NotNull]
        public string Path { get; set; }
    }
}