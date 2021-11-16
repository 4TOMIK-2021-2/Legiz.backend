using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Services.Communication;

namespace Legiz.Back_End.LawServiceBC.Domain.Services
{
    public interface ILegalDocumentService
    {
        Task<IEnumerable<LegalDocument>> ListAsync();
        Task<LegalDocumentResponse> GetByIdAsync(int id);
        Task<LegalDocumentResponse> SaveAsync(LegalDocument legalDocument);
        Task<LegalDocumentResponse> UpdateAsync(int id, LegalDocument legalDocument);
        Task<LegalDocumentResponse> DeleteAsync(int id);
    }
}