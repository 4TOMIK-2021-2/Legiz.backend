using Legiz.Back_End.UserProfileBC.Resources;

namespace Legiz.Back_End.LawServiceBC.Resources
{
    public class LegalAdviceResource
    {
        public int Id { get; set; }
        public string StatusLawService { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LegalResponse { get; set; }
        public LawyerResource Lawyer { get; set; }
        public CustomerResource Customer { get; set; }
        public LegalDocumentResource LegalDocument { get; set; }
    }
}