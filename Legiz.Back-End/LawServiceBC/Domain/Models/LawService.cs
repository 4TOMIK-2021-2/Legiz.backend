using Legiz.Back_End.UserProfileBC.Domain.Models;

namespace Legiz.Back_End.LawServiceBC.Domain.Models
{
    public class LawService
    {
        public int Id { get; set; }
        public EStatusLawService StatusLawService { get; set; }
        public string Title { get; set; }
        public Lawyer Lawyer { get; set; }
        public int LawyerId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public LegalDocument LegalDocument { get; set; }
        public int LegalDocumentId { get; set; }
    }
}