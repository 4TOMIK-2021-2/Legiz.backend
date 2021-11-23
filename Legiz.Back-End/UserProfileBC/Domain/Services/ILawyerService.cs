using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;

namespace Legiz.Back_End.UserProfileBC.Domain.Services
{
    public interface ILawyerService
    {
        Task<IEnumerable<Lawyer>> ListAsync();
        Task<Lawyer> GetByIdAsync(int id);
        Task RegisterAsync(RegisterLawyerRequest lawyer);
        Task UpdateAsync(int id, UpdateLawyerRequest lawyer);
        Task DeleteAsync(int id);
    }
}