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
    public class LegalDocumentsController : ControllerBase
    {
        private readonly ILegalDocumentService _legalDocumentService;
        private readonly IMapper _mapper;

        public LegalDocumentsController(IMapper mapper, ILegalDocumentService legalDocumentService)
        {
            _mapper = mapper;
            _legalDocumentService = legalDocumentService;
        }
        
        [SwaggerOperation(
            Summary = "Get All Legal Documents",
            Description = "Get All Legal Documents already stored",
            Tags = new[] {"Documents"})]
        [HttpGet]
        public async Task<IEnumerable<LegalDocumentResource>> GetAllAsync()
        {
            var legalDocuments = await _legalDocumentService.ListAsync();
            var resource = _mapper.Map<IEnumerable<LegalDocument>,IEnumerable<LegalDocumentResource>>(legalDocuments);
            
            return resource;
        }
        
        [SwaggerOperation(
            Summary = "Post Legal Document",
            Description = "Post new Legal Document",
            Tags = new[] {"Documents"})]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveLegalDocumentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var legalDocument = _mapper.Map<SaveLegalDocumentResource, LegalDocument>(resource);

            var result = await _legalDocumentService.SaveAsync(legalDocument);

            if (!result.Success)
                return BadRequest(result.Message);

            var legalDocumentResource = _mapper.Map<LegalDocument, LegalDocumentResource>(result.Resource);
            return Ok(legalDocumentResource);
        }
        
        [SwaggerOperation(
            Summary = "Update Legal Document By Id",
            Description = "Update Legal Document already stored",
            Tags = new[] {"Documents"})]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLegalDocumentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var legalDocument = _mapper.Map<SaveLegalDocumentResource, LegalDocument>(resource);

            var result = await _legalDocumentService.UpdateAsync(id, legalDocument);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var legalDocumentResource = _mapper.Map<LegalDocument, LegalDocumentResource>(result.Resource);
            return Ok(legalDocumentResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete Legal Document By Id",
            Description = "Delete Legal Document already stored",
            Tags = new[] {"Documents"})]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _legalDocumentService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var legalDocumentResource = _mapper.Map<LegalDocument, LegalDocumentResource>(result.Resource);
            return Ok(legalDocumentResource);
        }
        
        [SwaggerOperation(
            Summary = "Get Legal Document By Id",
            Description = "Get Legal Document already stored",
            Tags = new[] {"Documents"})]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _legalDocumentService.GetByIdAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var legalDocumentResource = _mapper.Map<LegalDocument, LegalDocumentResource>(result.Resource);
            return Ok(legalDocumentResource);
        }
    }
}