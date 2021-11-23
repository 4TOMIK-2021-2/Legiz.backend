using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Services.Communication;

namespace Legiz.Back_End.LawServiceBC.Domain.Services
{
    public interface ILegalAdviceService
    {
        Task<IEnumerable<LegalAdvice>> ListAsync(); 
        Task<LegalAdviceResponse> GetByIdAsync(int id); 
        Task<LegalAdviceResponse> SaveAsync(LegalAdvice legalAdvice); 
        Task<LegalAdviceResponse> UpdateAsync(int id, LegalAdvice legalAdvice);
    }
}