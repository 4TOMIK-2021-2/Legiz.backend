using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.Shared.Domain.Services.Communication;

namespace Legiz.Back_End.LawServiceBC.Domain.Services.Communication
{
    public class LegalDocumentResponse : BaseResponse<LegalDocument>
    {
        public LegalDocumentResponse(string message) : base(message)
        {
        }

        public LegalDocumentResponse(LegalDocument resource) : base(resource)
        {
        }
    }
}