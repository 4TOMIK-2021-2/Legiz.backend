using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Repositories;
using Legiz.Back_End.LawServiceBC.Domain.Services;
using Legiz.Back_End.LawServiceBC.Domain.Services.Communication;
using Legiz.Back_End.Shared.Domain.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Repositories;

namespace Legiz.Back_End.LawServiceBC.Services
{
    public class CustomLegalCaseService : ICustomLegalCaseService
    {
        private readonly ICustomLegalCaseRepository _customLegalCaseRepository;
        private readonly ILawyerRepository _lawyerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILegalDocumentRepository _legalDocumentRepository;

        public CustomLegalCaseService(ICustomLegalCaseRepository customLegalCaseRepository, IUnitOfWork unitOfWork, ILawyerRepository lawyerRepository, ICustomerRepository customerRepository, ILegalDocumentRepository legalDocumentRepository)
        {
            _customLegalCaseRepository = customLegalCaseRepository;
            _unitOfWork = unitOfWork;
            _lawyerRepository = lawyerRepository;
            _customerRepository = customerRepository;
            _legalDocumentRepository = legalDocumentRepository;
        }

        public async Task<IEnumerable<CustomLegalCase>> ListAsync()
        {
            return await _customLegalCaseRepository.ListAsync();
        }

        public async Task<CustomLegalCaseResponse> GetByIdAsync(int id)
        {
            var existingCustomLegalCase = await _customLegalCaseRepository.FindByIdAsync(id);

            if (existingCustomLegalCase == null)
                return new CustomLegalCaseResponse("Custom Legal Case not found.");

            try
            {
                await _unitOfWork.CompleteAsync();

                return new CustomLegalCaseResponse(existingCustomLegalCase);
            }
            catch (Exception e)
            {
                return new CustomLegalCaseResponse($"An error occurred while finding the Custom Legal Case: {e.Message}");
            }
        }

        public async Task<CustomLegalCaseResponse> SaveAsync(CustomLegalCase customLegalCase)
        {
            // Validate LawyerId
            var existingLawyer = _lawyerRepository.FindByIdAsync(customLegalCase.LawyerId);

            if (existingLawyer == null)
                return new CustomLegalCaseResponse("Invalid Lawyer");

            // Validate CustomerId
            var existingCustomer = _customerRepository.FindByIdAsync(customLegalCase.CustomerId);

            if (existingCustomer == null)
                return new CustomLegalCaseResponse("Invalid Customer");
            
            // Validate LegalDocumentId
            var existingLegalDocument = _legalDocumentRepository.FindByIdAsync(customLegalCase.LegalDocumentId);
            
            if (existingLegalDocument == null)
                return new CustomLegalCaseResponse("Invalid Legal Document");
            
            try
            {
                await _customLegalCaseRepository.AddAsync(customLegalCase);
                await _unitOfWork.CompleteAsync();

                return new CustomLegalCaseResponse(customLegalCase);
            }
            catch (Exception e)
            {
                return new CustomLegalCaseResponse($"An error occurred while saving the Custom Legal Case: {e.Message}");
            }
        }

        public async Task<CustomLegalCaseResponse> UpdateAsync(int id, CustomLegalCase customLegalCase)
        {
            // Validate CustomLegalCaseId
            var existingCustomLegalCase = await _customLegalCaseRepository.FindByIdAsync(id);

            if (existingCustomLegalCase == null)
                return new CustomLegalCaseResponse("Custom Legal Case not found.");
            
            // Validate LawyerId
            var existingLawyer = _lawyerRepository.FindByIdAsync(customLegalCase.LawyerId);

            if (existingLawyer == null)
                return new CustomLegalCaseResponse("Invalid Lawyer");

            // Validate CustomerId
            var existingCustomer = _customerRepository.FindByIdAsync(customLegalCase.CustomerId);

            if (existingCustomer == null)
                return new CustomLegalCaseResponse("Invalid Customer");
            
            // Validate LegalDocumentId
            var existingLegalDocument = _legalDocumentRepository.FindByIdAsync(customLegalCase.LegalDocumentId);
            
            if (existingLegalDocument == null)
                return new CustomLegalCaseResponse("Invalid Legal Document");

            existingCustomLegalCase.StatusLawService = customLegalCase.StatusLawService;
            existingCustomLegalCase.StartAt = customLegalCase.StartAt;
            existingCustomLegalCase.FinishAt = customLegalCase.FinishAt;
            existingCustomLegalCase.LinkZoom = customLegalCase.LinkZoom;
            
            try
            {
                _customLegalCaseRepository.Update(existingCustomLegalCase);
                await _unitOfWork.CompleteAsync();

                return new CustomLegalCaseResponse(existingCustomLegalCase);
            }
            catch (Exception e)
            {
                return new CustomLegalCaseResponse($"An error occurred while updating the Custom Legal Case: {e.Message}");
            }
        }
    }
}