using Legiz.Back_End.Shared.Domain.Services.Communication;
using Legiz.Back_End.UserProfileBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Services.Communication
{
    public class LawyerResponse : BaseResponse<Lawyer>
    {
        public LawyerResponse(string message) : base(message)
        {
        }

        public LawyerResponse(Lawyer resource) : base(resource)
        {
        }
    }
}