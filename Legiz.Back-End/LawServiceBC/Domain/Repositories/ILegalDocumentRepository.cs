using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;

namespace Legiz.Back_End.LawServiceBC.Domain.Repositories
{
    public interface ILegalDocumentRepository
    {
        Task<IEnumerable<LegalDocument>> ListAsync();
        Task AddAsync(LegalDocument legalDocument);
        Task<LegalDocument> FindByIdAsync(int id);
        void Update(LegalDocument legalDocument);
        void Remove(LegalDocument legalDocument);
    }
}