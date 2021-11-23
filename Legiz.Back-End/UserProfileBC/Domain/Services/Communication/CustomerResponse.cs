using Legiz.Back_End.Shared.Domain.Services.Communication;
using Legiz.Back_End.UserProfileBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Services.Communication
{
    public class CustomerResponse : BaseResponse<Customer>
    {
        public CustomerResponse(string message) : base(message)
        {
        }

        public CustomerResponse(Customer resource) : base(resource)
        {
        }
    }
}