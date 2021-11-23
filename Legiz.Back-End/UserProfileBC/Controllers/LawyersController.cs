using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.SecurityBC.Authorization.Attributes;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Services;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;
using Legiz.Back_End.UserProfileBC.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Legiz.Back_End.UserProfileBC.Controllers
{
    [Authorize]
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
        
        // ALL LAWYERS
        [SwaggerOperation(
            Summary = "Get All Lawyers",
            Description = "Get All Lawyers already stored",
            Tags = new[] {"Lawyers"})]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lawyers = await _lawyerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Lawyer>,IEnumerable<LawyerSubscriptionResource>>(lawyers);
            return Ok(resources);
        }

        // REGISTER
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Post Lawyer",
            Description = "Post new Lawyer",
            Tags = new[] {"Lawyers"})]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult> PostAsync(RegisterLawyerRequest request)
        {
            await _lawyerService.RegisterAsync(request);
            return Ok(new {message = "Registration successful."});
        }
        
        // UPDATE
        [SwaggerOperation(
            Summary = "Update Lawyer By Id",
            Description = "Update Lawyer already stored",
            Tags = new[] {"Lawyers"})]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UpdateLawyerRequest request)
        {
            await _lawyerService.UpdateAsync(id, request);
            return Ok(new {message = "Lawyer updated successfully"});
        }
        
        // DELETE
        [SwaggerOperation(
            Summary = "Delete Lawyer By Id",
            Description = "Delete Lawyer already stored",
            Tags = new[] {"Lawyers"})]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _lawyerService.DeleteAsync(id);
            return Ok(new {message = "Lawyer deleted successfully"});
        }
        
        // GET BY
        [SwaggerOperation(
            Summary = "Get Lawyer By Id",
            Description = "Get Lawyer already stored",
            Tags = new[] {"Lawyers"})]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var lawyer = await _lawyerService.GetByIdAsync(id);
            var resource = _mapper.Map<Lawyer, LawyerSubscriptionResource>(lawyer);
            return Ok(resource);
        }
    }
}