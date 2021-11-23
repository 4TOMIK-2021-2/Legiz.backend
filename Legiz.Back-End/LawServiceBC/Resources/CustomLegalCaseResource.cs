using System;
using Legiz.Back_End.UserProfileBC.Resources;

namespace Legiz.Back_End.LawServiceBC.Resources
{
    public class CustomLegalCaseResource
    {
        public int Id { get; set; }
        public string StatusLawService { get; set; }
        public string Title { get; set; }
        public string StartAt { get; set; }
        public string FinishAt { get; set; }
        public string TypeMeet { get; set; }
        public string LinkZoom { get; set; }
        public LawyerResource Lawyer { get; set; }
        public CustomerResource Customer { get; set; }
        public LegalDocumentResource LegalDocument { get; set; }
    }
}