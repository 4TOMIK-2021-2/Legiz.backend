using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Repositories;
using Legiz.Back_End.Shared.Persistence.Contexts;
using Legiz.Back_End.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.LawServiceBC.Persistence.Repositories
{
    public class LegalDocumentRepository : BaseRepository, ILegalDocumentRepository
    {
        public LegalDocumentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LegalDocument>> ListAsync()
        {
            return await _context.LegalDocuments.ToListAsync();
        }

        public async Task AddAsync(LegalDocument legalDocument)
        { 
            await _context.LegalDocuments.AddAsync(legalDocument);
        }

        public async Task<LegalDocument> FindByIdAsync(int id)
        {
            return await _context.LegalDocuments.FindAsync(id);
        }

        public void Update(LegalDocument legalDocument)
        {
            _context.LegalDocuments.Update(legalDocument);
        }

        public void Remove(LegalDocument legalDocument)
        {
            _context.LegalDocuments.Remove(legalDocument);
        }
    }
}