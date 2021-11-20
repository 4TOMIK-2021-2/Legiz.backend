using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.Shared.Domain.Services.Communication;

namespace Legiz.Back_End.LawServiceBC.Domain.Services.Communication
{
    public class LegalAdviceResponse : BaseResponse<LegalAdvice>
    {
        public LegalAdviceResponse(string message) : base(message)
        {
        }

        public LegalAdviceResponse(LegalAdvice resource) : base(resource)
        {
        }
    }
}