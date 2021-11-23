using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.UserProfileBC.Domain.Models;

namespace Legiz.Back_End.UserProfileBC.Domain.Repositories
{
    public interface ILawyerRepository
    {
        Task<IEnumerable<Lawyer>> ListAsync();
        Task AddAsync(Lawyer lawyer);
        Task<Lawyer> FindByIdAsync(int id);
        Lawyer FindById(int id);
        void Update(Lawyer lawyer);
        void Remove(Lawyer lawyer);
    }
}