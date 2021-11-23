using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.SecurityBC.Authorization.Attributes;
using Legiz.Back_End.Shared.Extensions;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Services;
using Legiz.Back_End.UserProfileBC.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Legiz.Back_End.UserProfileBC.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IMapper _mapper;

        public SubscriptionsController(IMapper mapper, ISubscriptionService subscriptionService)
        {
            _mapper = mapper;
            _subscriptionService = subscriptionService;
        }
        
        [SwaggerOperation(
            Summary = "Get All Subscriptions",
            Description = "Get All Subscriptions already stored",
            Tags = new[] {"Subscriptions"})]
        [HttpGet]
        public async Task<IEnumerable<SubscriptionResource>> GetAllAsync()
        {
            var subscriptions = await _subscriptionService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Subscription>,IEnumerable<SubscriptionResource>>(subscriptions);
            
            return resource;
        }
        
        [SwaggerOperation(
            Summary = "Post Subscription",
            Description = "Post new Subscription",
            Tags = new[] {"Subscriptions"})]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubscriptionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var subscription = _mapper.Map<SaveSubscriptionResource, Subscription>(resource);

            var result = await _subscriptionService.SaveAsync(subscription);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }
        
        [SwaggerOperation(
            Summary = "Get Subscription By Id",
            Description = "Get Subscription already stored",
            Tags = new[] {"Subscriptions"})]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _subscriptionService.GetByIdAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionResource = _mapper.Map<Subscription, SubscriptionResource>(result.Resource);
            return Ok(subscriptionResource);
        }
    }
}