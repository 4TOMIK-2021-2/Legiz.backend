using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;

namespace Legiz.Back_End.UserProfileBC.Domain.Services
{
    public interface ILawyerService
    {
        Task<IEnumerable<Lawyer>> ListAsync();
        Task<LawyerResponse> GetByIdAsync(int id);
        Task<LawyerResponse> SaveAsync(Lawyer lawyer);
        Task<LawyerResponse> UpdateAsync(int id, Lawyer lawyer);
        Task<LawyerResponse> DeleteAsync(int id);
    }
}