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
    [Route("/api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        
        [SwaggerOperation(
            Summary = "Get All Customers",
            Description = "Get All Customers already stored",
            Tags = new[] {"Customers"})]
        [HttpGet]
        public async Task<IEnumerable<CustomerResource>> GetAllAsync()
        {
            var customers = await _customerService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Customer>,IEnumerable<CustomerResource>>(customers);
            
            return resource;
        }
        
        [SwaggerOperation(
            Summary = "Post Customer",
            Description = "Post new Customer",
            Tags = new[] {"Customers"})]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);

            var result = await _customerService.SaveAsync(customer);

            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
            return Ok(customerResource);
        }
        
        [SwaggerOperation(
            Summary = "Update Customer By Id",
            Description = "Update Customer already stored",
            Tags = new[] {"Customers"})]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);

            var result = await _customerService.UpdateAsync(id, customer);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
            return Ok(customerResource);
        }
        
        [SwaggerOperation(
            Summary = "Delete Customer By Id",
            Description = "Delete Customer already stored",
            Tags = new[] {"Customers"})]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _customerService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
            return Ok(customerResource);
        }
        
        [SwaggerOperation(
            Summary = "Get Customer By Id",
            Description = "Get Customer already stored",
            Tags = new[] {"Customers"})]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _customerService.GetByIdAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
            return Ok(customerResource);
        }
    }
}