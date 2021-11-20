using System.Collections.Generic;

namespace Legiz.Back_End.LawServiceBC.Domain.Models
{
    public class LegalDocument
    {
        public int Id { get; set; }
        public string DocumentTitle { get; set; }
        public string Path { get; set; }
        public IList<CustomLegalCase> CustomLegalCases { get; set; } = new List<CustomLegalCase>();
        public IList<LegalAdvice> LegalAdvices { get; set; } = new List<LegalAdvice>();
    }
}