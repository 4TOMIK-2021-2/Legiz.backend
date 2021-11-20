using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.Shared.Persistence.Contexts;
using Legiz.Back_End.Shared.Persistence.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.UserProfileBC.Persistence.Repositories
{
    public class LawyerRepository: BaseRepository, ILawyerRepository
    {
        public LawyerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Lawyer>> ListAsync()
        {
            return await _context.Lawyers
                .Include(p => p.Subscription)
                .ToListAsync();
        }

        public async Task AddAsync(Lawyer lawyer)
        {
            await _context.Lawyers.AddAsync(lawyer);
        }

        public async Task<Lawyer> FindByIdAsync(int id)
        {
            return await _context.Lawyers
                .Include(p => p.Subscription)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(Lawyer lawyer)
        {
            _context.Lawyers.Update(lawyer);
        }

        public void Remove(Lawyer lawyer)
        {
            _context.Lawyers.Remove(lawyer);
        }
    }
}