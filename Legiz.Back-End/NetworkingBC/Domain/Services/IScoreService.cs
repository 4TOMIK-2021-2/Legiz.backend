using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Domain.Services.Communication;

namespace Legiz.Back_End.NetworkingBC.Domain.Services
{
    public interface IScoreService
    {
        Task<IEnumerable<Score>> ListAsync();
        
        Task<ScoreResponse> FindByIdAsync(int id);
        Task<ScoreResponse> SaveAsync(Score score);
    }
}