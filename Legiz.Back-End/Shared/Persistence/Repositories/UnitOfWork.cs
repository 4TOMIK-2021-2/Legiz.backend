using System.Threading.Tasks;
using Legiz.Back_End.Shared.Domain.Repositories;
using Legiz.Back_End.Shared.Persistence.Contexts;

namespace Legiz.Back_End.Shared.Persistence.Repositories
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