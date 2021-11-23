using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Legiz.Back_End.SecurityBC.Domain.Repositories;
using Legiz.Back_End.SecurityBC.Exceptions;
using Legiz.Back_End.Shared.Domain.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Services;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Legiz.Back_End.UserProfileBC.Services
{
    public class LawyerService : ILawyerService
    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        
        public LawyerService(ILawyerRepository lawyerRepository, IUnitOfWork unitOfWork, ISubscriptionRepository subscriptionRepository, IUserRepository userRepository, IMapper mapper)
        {
            _lawyerRepository = lawyerRepository;
            _unitOfWork = unitOfWork;
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Lawyer>> ListAsync()
        {
            return await _lawyerRepository.ListAsync();
        }

        public async Task<Lawyer> GetByIdAsync(int id)
        {
            var lawyer = await _lawyerRepository.FindByIdAsync(id);
            if (lawyer == null) throw new KeyNotFoundException("Lawyer not found");
            return lawyer;
        }

        public async Task RegisterAsync(RegisterLawyerRequest request)
        {
            // Validate SubscriptionId
            var existingSubscription = _subscriptionRepository.FindByIdAsync(request.SubscriptionId);

            if (existingSubscription == null)
                throw new AppException($"SubscriptionId {request.SubscriptionId} not found");
            
            //Validate
            if (_userRepository.ExistsByUsername(request.Username))
                throw new AppException($"Lawyer {request.Username} is already taken.");
            
            //Map request to Customer
            var lawyer = _mapper.Map<Lawyer>(request);
            
            //Hash password
            lawyer.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            //Save Customer
            try
            {
                await _lawyerRepository.AddAsync(lawyer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the lawyer: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateLawyerRequest request)
        {
            var lawyer = GetById(id);

            // Validate
            if (_userRepository.ExistsByUsername(request.Username))
                throw new AppException($"Customer {request.Username} is already taken.");

            // Hash Password if entered
            if (!string.IsNullOrEmpty(request.Password))
                lawyer.PasswordHash = BCryptNet.HashPassword(request.Password);

            // Map request to Customer
            _mapper.Map(request, lawyer);

            try
            {
                _lawyerRepository.Update(lawyer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the Lawyer: {e.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var lawyer = GetById(id);
            try
            {
                _lawyerRepository.Remove(lawyer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the Lawyer: {e.Message}");
            }
        }
        // Helper Methods
        private Lawyer GetById(int id)
        {
            var lawyer = _lawyerRepository.FindById(id);
            if (lawyer == null) throw new KeyNotFoundException("Lawyer not found.");
            return lawyer;
        }
    }
}