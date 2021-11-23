using Legiz.Back_End.LawServiceBC.Domain.Models;

namespace Legiz.Back_End.NetworkingBC.Resources
{
    public class ScoreResource
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public string Comment { get; set; }
        public CustomLegalCase CustomLegalCase { get; set; }
        public LegalAdvice LegalAdvice { get; set; }
    }
}