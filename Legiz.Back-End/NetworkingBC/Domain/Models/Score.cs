using Legiz.Back_End.LawServiceBC.Domain.Models;

namespace Legiz.Back_End.NetworkingBC.Domain.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Comment { get; set; }
        
        public int CustomLegalCaseId { get; set; }
        public CustomLegalCase CustomLegalCase { get; set; }
        
        public int LegalAdviceId { get; set; }
        public LegalAdvice LegalAdvice { get; set; }
    }
}