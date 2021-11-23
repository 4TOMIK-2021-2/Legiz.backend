using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.SecurityBC.Domain.Models;
using Legiz.Back_End.SecurityBC.Domain.Services.Communication;

namespace Legiz.Back_End.SecurityBC.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(int id);
    }
}