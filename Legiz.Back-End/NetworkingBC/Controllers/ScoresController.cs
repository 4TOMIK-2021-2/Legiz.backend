using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Legiz.Back_End.NetworkingBC.Controllers
{
    [Route("/api/v1/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _scoreService;

        public ScoresController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public async Task<IEnumerable<Score>> GetAllAsync()
        {
            var scores = await _scoreService.ListAsync();
            return scores;
        }
    }
}