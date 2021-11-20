using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;

namespace Legiz.Back_End.LawServiceBC.Domain.Repositories
{
    public interface ILegalAdviceRepository
    {
        Task<IEnumerable<LegalAdvice>> ListAsync();
        Task AddAsync(LegalAdvice legalAdvice);
        Task<LegalAdvice> FindByIdAsync(int id);
        void Update(LegalAdvice legalAdvice);
    }
}