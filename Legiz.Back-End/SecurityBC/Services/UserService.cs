using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.SecurityBC.Authorization.Handlers.Interfaces;
using Legiz.Back_End.SecurityBC.Domain.Models;
using Legiz.Back_End.SecurityBC.Domain.Repositories;
using Legiz.Back_End.SecurityBC.Domain.Services;
using Legiz.Back_End.SecurityBC.Domain.Services.Communication;
using Legiz.Back_End.SecurityBC.Exceptions;
using Legiz.Back_End.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Legiz.Back_End.SecurityBC.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = await _userRepository.FindByUsernameAsync(request.Username);
            
            // Validate
            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect.");
            
            // Authentication successful
            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtHandler.GenerateToken(user);
            return response;
        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}