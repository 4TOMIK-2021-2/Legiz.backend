using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Services.Communication;

namespace Legiz.Back_End.LawServiceBC.Domain.Services
{
    public interface ICustomLegalCaseService
    {
        Task<IEnumerable<CustomLegalCase>> ListAsync(); 
        Task<CustomLegalCaseResponse> GetByIdAsync(int id); 
        Task<CustomLegalCaseResponse> SaveAsync(CustomLegalCase customLegalCase); 
        Task<CustomLegalCaseResponse> UpdateAsync(int id, CustomLegalCase customLegalCase);
    }
}