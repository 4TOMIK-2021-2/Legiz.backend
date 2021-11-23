using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Domain.Repository;
using Legiz.Back_End.Shared.Persistence.Contexts;
using Legiz.Back_End.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Legiz.Back_End.NetworkingBC.Persistence.Repositories
{
    public class ScoreRepository : BaseRepository, IScoreRepository
    {
        public ScoreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Score>> ListAsync()
        {
            return await _context.Scores.ToListAsync();
        }

        public async Task<Score> FindByIdAsync(int id)
        {
            return await _context.Scores
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Score score)
        {
            await _context.Scores.AddAsync(score);
            //return await _context.Scores.AddAsync(score);
        }
    }
}