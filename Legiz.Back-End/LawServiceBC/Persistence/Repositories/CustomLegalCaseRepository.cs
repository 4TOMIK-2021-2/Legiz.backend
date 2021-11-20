using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Repositories;
using Legiz.Back_End.Shared.Persistence.Contexts;
using Legiz.Back_End.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.LawServiceBC.Persistence.Repositories
{
    public class CustomLegalCaseRepository : BaseRepository, ICustomLegalCaseRepository
    {
        public CustomLegalCaseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CustomLegalCase>> ListAsync()
        {
            return await _context.CustomLegalCases
                .Include(p=>p.Lawyer)
                .Include(p=>p.Customer)
                .Include(p=>p.LegalDocument)
                .ToListAsync();
        }

        public async Task AddAsync(CustomLegalCase customLegalCase)
        {
            await _context.CustomLegalCases.AddAsync(customLegalCase);
        }

        public async Task<CustomLegalCase> FindByIdAsync(int id)
        {
            return await _context.CustomLegalCases
                .Include(p => p.Customer)
                .Include(p => p.Lawyer)
                .Include(p=>p.LegalDocument)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void Update(CustomLegalCase customLegalCase)
        {
            _context.CustomLegalCases.Update(customLegalCase);
        }
    }
}