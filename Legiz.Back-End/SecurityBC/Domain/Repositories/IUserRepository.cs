using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.SecurityBC.Domain.Models;

namespace Legiz.Back_End.SecurityBC.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUsernameAsync(string username);
        public bool ExistsByUsername(string username);
        User FindById(int id);
    }
}