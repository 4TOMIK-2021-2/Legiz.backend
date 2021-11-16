using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.Shared.Domain.Services.Communication;

namespace Legiz.Back_End.LawServiceBC.Domain.Services.Communication
{
    public class CustomLegalCaseResponse : BaseResponse<CustomLegalCase>
    {
        public CustomLegalCaseResponse(string message) : base(message)
        {
        }

        public CustomLegalCaseResponse(CustomLegalCase resource) : base(resource)
        {
        }
    }
}