using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Services;
using Legiz.Back_End.LawServiceBC.Resources;
using Legiz.Back_End.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Legiz.Back_End.LawServiceBC.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CustomLegalCasesController : ControllerBase
    {
        private readonly ICustomLegalCaseService _customLegalCaseService;
        private readonly IMapper _mapper;

        public CustomLegalCasesController(IMapper mapper, ICustomLegalCaseService customLegalCaseService)
        {
            _mapper = mapper;
            _customLegalCaseService = customLegalCaseService;
        }
        
        [SwaggerOperation(
            Summary = "Get All Custom Legal Case",
            Description = "Get All Custom Legal Cases already stored",
            Tags = new[] {"CustomLegalCases"})]
        [HttpGet]
        public async Task<IEnumerable<CustomLegalCaseResource>> GetAllAsync()
        {
            var customLegalCases = await _customLegalCaseService.ListAsync();
            var resource = _mapper.Map<IEnumerable<CustomLegalCase>,IEnumerable<CustomLegalCaseResource>>(customLegalCases);
            
            return resource;
        }
        
        [SwaggerOperation(
            Summary = "Post Custom Legal Case",
            Description = "Post new Custom Legal Case",
            Tags = new[] {"CustomLegalCases"})]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomLegalCaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customLegalCase = _mapper.Map<SaveCustomLegalCaseResource, CustomLegalCase>(resource);

            var result = await _customLegalCaseService.SaveAsync(customLegalCase);

            if (!result.Success)
                return BadRequest(result.Message);

            var customLegalCaseResource = _mapper.Map<CustomLegalCase, CustomLegalCaseResource>(result.Resource);
            return Ok(customLegalCaseResource);
        }
        
        [SwaggerOperation(
            Summary = "Update Custom Legal Case By Id",
            Description = "Update Custom Legal Case already stored",
            Tags = new[] {"CustomLegalCases"})]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomLegalCaseResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customLegalCase = _mapper.Map<SaveCustomLegalCaseResource, CustomLegalCase>(resource);

            var result = await _customLegalCaseService.UpdateAsync(id, customLegalCase);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var customLegalCaseResource = _mapper.Map<CustomLegalCase, CustomLegalCaseResource>(result.Resource);
            return Ok(customLegalCaseResource);
        }
        
        [SwaggerOperation(
            Summary = "Get Custom Legal Case By Id",
            Description = "Get Custom Legal Case already stored",
            Tags = new[] {"CustomLegalCases"})]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _customLegalCaseService.GetByIdAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var customLegalCaseResource = _mapper.Map<CustomLegalCase, CustomLegalCaseResource>(result.Resource);
            return Ok(customLegalCaseResource);
        }
    }
}