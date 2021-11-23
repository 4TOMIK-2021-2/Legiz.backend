using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;

namespace Legiz.Back_End.UserProfileBC.Domain.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<Customer> GetByIdAsync(int id);
        Task RegisterAsync(RegisterCustomerRequest customer);
        Task UpdateAsync(int id, UpdateCustomerRequest customer);
        Task DeleteAsync(int id);
    }
}