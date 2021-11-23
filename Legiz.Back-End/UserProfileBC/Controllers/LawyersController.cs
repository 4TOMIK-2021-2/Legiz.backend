using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.Shared.Extensions;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Services;
using Legiz.Back_End.UserProfileBC.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Legiz.Back_End.UserProfileBC.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/v1/[controller]")]
    public class LawyersController : ControllerBase
    {
        private readonly ILawyerService _lawyerService;
        private readonly IMapper _mapper;

        public LawyersController(ILawyerService lawyerService, IMapper mapper)
        {
            _lawyerService = lawyerService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Lawyers",
            Description = "Get All Lawyers already stored",
            Tags = new[] {"Lawyers"})]
        [HttpGet]
        public async Task<IEnumerable<LawyerSubscriptionResource>> GetAllAsync()
        {
            var lawyers = await _lawyerService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Lawyer>,IEnumerable<LawyerSubscriptionResource>>(lawyers);
            
            return resource;
        }

        [SwaggerOperation(
            Summary = "Post Lawyer",
            Description = "Post new Lawyer",
            Tags = new[] {"Lawyers"})]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveLawyerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var lawyer = _mapper.Map<SaveLawyerResource, Lawyer>(resource);

            var result = await _lawyerService.SaveAsync(lawyer);

            if (!result.Success)
                return BadRequest(result.Message);

            var lawyerResource = _mapper.Map<Lawyer, LawyerSubscriptionResource>(result.Resource);
            return Ok(lawyerResource);
        }
        
        [SwaggerOperation(
            Summary = "Update Lawyer By Id",
            Description = "Update Lawyer already stored",
            Tags = new[] {"Lawyers"})]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLawyerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var lawyer = _mapper.Map<SaveLawyerResource, Lawyer>(resource);

            var result = await _lawyerService.UpdateAsync(id, lawyer);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Lawyer, LawyerSubscriptionResource>(result.Resource);
            return Ok(customerResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete Lawyer By Id",
            Description = "Delete Lawyer already stored",
            Tags = new[] {"Lawyers"})]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _lawyerService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var lawyerResource = _mapper.Map<Lawyer, LawyerSubscriptionResource>(result.Resource);
            return Ok(lawyerResource);
        }
        
        [SwaggerOperation(
            Summary = "Get Lawyer By Id",
            Description = "Get Lawyer already stored",
            Tags = new[] {"Lawyers"})]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _lawyerService.GetByIdAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var lawyerResource = _mapper.Map<Lawyer, LawyerSubscriptionResource>(result.Resource);
            return Ok(lawyerResource);
        }
    }
}