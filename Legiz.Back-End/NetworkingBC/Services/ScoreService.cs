using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Domain.Repository;
using Legiz.Back_End.NetworkingBC.Domain.Services;

namespace Legiz.Back_End.NetworkingBC.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task<IEnumerable<Score>> ListAsync()
        {
            return await _scoreRepository.ListAsync();
        }
    }
}