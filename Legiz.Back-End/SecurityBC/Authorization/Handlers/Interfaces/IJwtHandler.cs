using Legiz.Back_End.SecurityBC.Domain.Models;

namespace Legiz.Back_End.SecurityBC.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}