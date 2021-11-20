using Legiz.Back_End.Shared.Persistence.Contexts;

namespace Legiz.Back_End.Shared.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}