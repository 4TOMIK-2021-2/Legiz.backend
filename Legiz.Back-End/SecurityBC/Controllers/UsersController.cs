using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.SecurityBC.Authorization.Attributes;
using Legiz.Back_End.SecurityBC.Domain.Models;
using Legiz.Back_End.SecurityBC.Domain.Services;
using Legiz.Back_End.SecurityBC.Domain.Services.Communication;
using Legiz.Back_End.SecurityBC.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Legiz.Back_End.SecurityBC.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.ListAsync();
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(resources);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var resource = _mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }
    }
}