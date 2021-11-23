using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Services;
using Legiz.Back_End.LawServiceBC.Resources;
using Legiz.Back_End.SecurityBC.Authorization.Attributes;
using Legiz.Back_End.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Legiz.Back_End.LawServiceBC.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class LegalAdvicesController : ControllerBase
    {
        private readonly ILegalAdviceService _legalAdviceService;
        private readonly IMapper _mapper;

        public LegalAdvicesController(IMapper mapper, ILegalAdviceService legalAdviceService)
        {
            _mapper = mapper;
            _legalAdviceService = legalAdviceService;
        }
        
        [SwaggerOperation(
            Summary = "Get All Legal Advice",
            Description = "Get All Legal Advices already stored",
            Tags = new[] {"LegalAdvices"})]
        [HttpGet]
        public async Task<IEnumerable<LegalAdviceResource>> GetAllAsync()
        {
            var legalAdvices = await _legalAdviceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<LegalAdvice>,IEnumerable<LegalAdviceResource>>(legalAdvices);
            
            return resources;
        }
        
        [SwaggerOperation(
            Summary = "Post Legal Advice",
            Description = "Post new Legal Advice",
            Tags = new[] {"LegalAdvices"})]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveLegalAdviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var legalAdvice = _mapper.Map<SaveLegalAdviceResource, LegalAdvice>(resource);

            var result = await _legalAdviceService.SaveAsync(legalAdvice);

            if (!result.Success)
                return BadRequest(result.Message);

            var legalAdviceResource = _mapper.Map<LegalAdvice, LegalAdviceResource>(result.Resource);
            
            return Ok(legalAdviceResource);
        }
        
        [SwaggerOperation(
            Summary = "Update Legal Advice By Id",
            Description = "Update Legal Advice already stored",
            Tags = new[] {"LegalAdvices"})]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLegalAdviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var legalAdvice = _mapper.Map<SaveLegalAdviceResource, LegalAdvice>(resource);

            var result = await _legalAdviceService.UpdateAsync(id, legalAdvice);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var legalAdviceResource = _mapper.Map<LegalAdvice, LegalAdviceResource>(result.Resource);
            
            return Ok(legalAdviceResource);
        }
        
        [SwaggerOperation(
            Summary = "Get Legal Advice By Id",
            Description = "Get Legal Advice already stored",
            Tags = new[] {"LegalAdvices"})]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _legalAdviceService.GetByIdAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var legalAdviceResource = _mapper.Map<LegalAdvice, LegalAdviceResource>(result.Resource);
            return Ok(legalAdviceResource);
        }
    }
}