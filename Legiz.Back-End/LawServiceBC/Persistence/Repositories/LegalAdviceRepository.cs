using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Repositories;
using Legiz.Back_End.Shared.Persistence.Contexts;
using Legiz.Back_End.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.LawServiceBC.Persistence.Repositories
{
    public class LegalAdviceRepository : BaseRepository, ILegalAdviceRepository
    {
        public LegalAdviceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LegalAdvice>> ListAsync()
        {
            return await _context.LegalAdvices
                .Include(p=>p.Lawyer)
                .Include(p=>p.Customer)
                .Include(p=>p.LegalDocument)
                .ToListAsync();
        }

        public async Task AddAsync(LegalAdvice legalAdvice)
        {
            await _context.LegalAdvices.AddAsync(legalAdvice);
        }

        public async Task<LegalAdvice> FindByIdAsync(int id)
        {
            return await _context.LegalAdvices
                .Include(p => p.Customer)
                .Include(p => p.Lawyer)
                .Include(p=>p.LegalDocument)
                .FirstOrDefaultAsync(p => p.Id == id);
                
        }

        public void Update(LegalAdvice legalAdvice)
        {
            _context.LegalAdvices.Update(legalAdvice);
        }
    }
}