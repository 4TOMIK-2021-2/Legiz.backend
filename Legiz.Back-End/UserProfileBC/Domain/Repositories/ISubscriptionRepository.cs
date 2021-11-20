using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.UserProfileBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> ListAsync();
        Task AddAsync(Subscription subscription);
        Task<Subscription> FindByIdAsync(int id);
    }
}