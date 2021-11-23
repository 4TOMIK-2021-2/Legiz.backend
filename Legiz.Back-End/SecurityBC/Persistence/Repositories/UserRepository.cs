using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legiz.Back_End.SecurityBC.Domain.Models;
using Legiz.Back_End.SecurityBC.Domain.Repositories;
using Legiz.Back_End.Shared.Persistence.Contexts;
using Legiz.Back_End.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.SecurityBC.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public User FindById(int id)
        {
            return _context.Users.Find(id);
        }
    }
}