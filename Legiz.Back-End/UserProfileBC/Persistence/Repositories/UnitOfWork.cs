using System.Threading.Tasks;
using Legiz.Back_End.Shared.Persistence;
using Legiz.Back_End.UserProfileBC.Domain.Repositories;

namespace Legiz.Back_End.UserProfileBC.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}