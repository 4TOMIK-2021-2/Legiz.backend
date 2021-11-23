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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        
        // ALL CUSTOMERS
        [SwaggerOperation(
            Summary = "Get All Customers",
            Description = "Get All Customers already stored",
            Tags = new[] {"Customers"})]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Customer>,IEnumerable<CustomerResource>>(customers);
            return Ok(resources);
        }
        
        // REGISTER
        [SwaggerOperation(
            Summary = "Register Customer",
            Description = "Register new Customer",
            Tags = new[] {"Customers"})]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost("auth/sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterCustomerRequest request)
        {
            await _customerService.RegisterAsync(request);
            return Ok(new {message = "Registration successful."});
        }
        
        // UPDATE
        [SwaggerOperation(
            Summary = "Update Customer By Id",
            Description = "Update Customer already stored",
            Tags = new[] {"Customers"})]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerRequest request)
        {
            await _customerService.UpdateAsync(id, request);
            return Ok(new {message = "Customer updated successfully"});
        }
        
        // DELETE
        [SwaggerOperation(
            Summary = "Delete Customer By Id",
            Description = "Delete Customer already stored",
            Tags = new[] {"Customers"})]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _customerService.DeleteAsync(id);
            return Ok(new {message = "Customer deleted successfully"});
        }
        
        // GET BY ID
        [SwaggerOperation(
            Summary = "Get Customer By Id",
            Description = "Get Customer already stored",
            Tags = new[] {"Customers"})]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            var resource = _mapper.Map<Customer, CustomerResource>(customer);
            return Ok(resource);
        }
    }
}