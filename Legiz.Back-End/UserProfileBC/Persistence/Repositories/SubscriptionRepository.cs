using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.Shared.Persistence.Contexts;
using Legiz.Back_End.Shared.Persistence.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.UserProfileBC.Persistence.Repositories
{
    public class SubscriptionRepository : BaseRepository, ISubscriptionRepository
    {
        public SubscriptionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
        }

        public async Task<Subscription> FindByIdAsync(int id)
        {
            return await _context.Subscriptions.FindAsync(id);
        }
    }
}