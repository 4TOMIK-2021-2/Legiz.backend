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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.FindByIdAsync(id);
            if (customer == null) throw new KeyNotFoundException("Customer not found");
            return customer;
        }
        public async Task RegisterAsync(RegisterCustomerRequest request)
        {
            //Validate
            if (_userRepository.ExistsByUsername(request.Username))
                throw new AppException($"Customer {request.Username} is already taken.");
            
            //Map request to Customer
            var customer = _mapper.Map<Customer>(request);
            
            //Hash password
            customer.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            //Save Customer
            try
            {
                await _customerRepository.AddAsync(customer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while saving the customer: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateCustomerRequest request)
        {
            var customer = GetById(id);
            
            // Validate
            if (_userRepository.ExistsByUsername(request.Username))
                throw new AppException($"Customer {request.Username} is already taken.");
            
            // Hash Password if entered
            if (!string.IsNullOrEmpty(request.Password))
                customer.PasswordHash = BCryptNet.HashPassword(request.Password);

            // Map request to Customer
            _mapper.Map(request, customer);
            
            try
            {
                _customerRepository.Update(customer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the Customer: {e.Message}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var customer = GetById(id);
            try
            {
                _customerRepository.Remove(customer);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the Customer: {e.Message}");
            }
        }
        // Helper Methods
        private Customer GetById(int id)
        {
            var customer = _customerRepository.FindById(id);
            if (customer == null) throw new KeyNotFoundException("Customer not found.");
            return customer;
        }
    }
}