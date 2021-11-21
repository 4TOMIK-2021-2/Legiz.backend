using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Resources;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Domain.Services;
using Legiz.Back_End.NetworkingBC.Resources;
using Legiz.Back_End.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Legiz.Back_End.NetworkingBC.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ScoresController : ControllerBase
    {
        private readonly IScoreService _scoreService;
        private readonly IMapper _mapper;

        public ScoresController(IMapper mapper, IScoreService scoreService)
        {
            _mapper = mapper;
            _scoreService = scoreService;
        }

        [SwaggerOperation(
            Summary = "Get All Scores",
            Description = "Get All scores already stored",
            Tags = new[] {"Scores"})]
        [HttpGet]
        public async Task<IEnumerable<ScoreResource>> GetAllAsync()
        {
            var scores = await _scoreService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Score>,IEnumerable<ScoreResource>>(scores);
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Post Score",
            Description = "Post new Score",
            Tags = new[] {"Scores"})]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveScoreResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var score = _mapper.Map<SaveScoreResource, Score>(resource);

            var result = await _scoreService.SaveAsync(score);

            if (!result.Success)
                return BadRequest(result.Message);

            var scoreResource = _mapper.Map<Score, ScoreResource>(result.Resource);
            return Ok(scoreResource);
        }
        
    }
}