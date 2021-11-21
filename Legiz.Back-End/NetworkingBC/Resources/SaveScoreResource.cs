using System.ComponentModel.DataAnnotations;

namespace Legiz.Back_End.NetworkingBC.Resources
{
    public class SaveScoreResource
    {
        [Required]
        [Range(1,5)]
        public int Star { get; set; }
        
        [Required]
        public string Comment { get; set; }
        
        public int CustomLegalCaseId { get; set; }
        
        public int LegalAdviceId { get; set; }
    }
}