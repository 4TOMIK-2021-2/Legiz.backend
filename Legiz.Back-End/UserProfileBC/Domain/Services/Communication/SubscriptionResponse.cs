using Legiz.Back_End.Shared.Domain.Services.Communication;
using Legiz.Back_End.UserProfileBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Services.Communication
{
    public class SubscriptionResponse : BaseResponse<Subscription>
    {
        public SubscriptionResponse(string message) : base(message)
        {
        }

        public SubscriptionResponse(Subscription resource) : base(resource)
        {
        }
    }
}