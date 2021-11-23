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
    public class LegalAdviceService : ILegalAdviceService
    {
        private readonly ILegalAdviceRepository _legalAdviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILawyerRepository _lawyerRepository;
        private readonly ILegalDocumentRepository _legalDocumentRepository;

        public LegalAdviceService(IUnitOfWork unitOfWork, ILegalAdviceRepository legalAdviceRepository, ICustomerRepository customerRepository, ILawyerRepository lawyerRepository, ILegalDocumentRepository legalDocumentRepository)
        {
            _unitOfWork = unitOfWork;
            _legalAdviceRepository = legalAdviceRepository;
            _customerRepository = customerRepository;
            _lawyerRepository = lawyerRepository;
            _legalDocumentRepository = legalDocumentRepository;
        }

        public async Task<IEnumerable<LegalAdvice>> ListAsync()
        {
            return await _legalAdviceRepository.ListAsync();
        }

        public async Task<LegalAdviceResponse> GetByIdAsync(int id)
        {
            var existingLegalAdvice = await _legalAdviceRepository.FindByIdAsync(id);

            if (existingLegalAdvice == null)
                return new LegalAdviceResponse("Legal Advice not found.");

            try
            {
                await _unitOfWork.CompleteAsync();

                return new LegalAdviceResponse(existingLegalAdvice);
            }
            catch (Exception e)
            {
                return new LegalAdviceResponse($"An error occurred while finding the Legal Advice: {e.Message}");
            }
        }

        public async Task<LegalAdviceResponse> SaveAsync(LegalAdvice legalAdvice)
        {
            // Validate LawyerId
            var existingLawyer = _lawyerRepository.FindByIdAsync(legalAdvice.LawyerId);

            if (existingLawyer == null)
                return new LegalAdviceResponse("Invalid Lawyer");

            // Validate CustomerId
            var existingCustomer = _customerRepository.FindByIdAsync(legalAdvice.CustomerId);

            if (existingCustomer == null)
                return new LegalAdviceResponse("Invalid Customer");
            
            // Validate LegalDocumentId
            var existingLegalDocument = _legalDocumentRepository.FindByIdAsync(legalAdvice.LegalDocumentId);
            
            if (existingLegalDocument == null)
                return new LegalAdviceResponse("Invalid Legal Document");
            
            try
            {
                await _legalAdviceRepository.AddAsync(legalAdvice);
                await _unitOfWork.CompleteAsync();

                return new LegalAdviceResponse(legalAdvice);
            }
            catch (Exception e)
            {
                return new LegalAdviceResponse($"An error occurred while saving the Legal Advice: {e.Message}");
            }
        }

        public async Task<LegalAdviceResponse> UpdateAsync(int id, LegalAdvice legalAdvice)
        {
            // Validate LegalAdviceId
            var existingLegalAdvice = await _legalAdviceRepository.FindByIdAsync(id);

            if (existingLegalAdvice == null)
                return new LegalAdviceResponse("Legal Advice not found.");
            
            // Validate LawyerId
            var existingLawyer = _lawyerRepository.FindByIdAsync(legalAdvice.LawyerId);

            if (existingLawyer == null)
                return new LegalAdviceResponse("Invalid Lawyer");

            // Validate CustomerId
            var existingCustomer = _customerRepository.FindByIdAsync(legalAdvice.CustomerId);

            if (existingCustomer == null)
                return new LegalAdviceResponse("Invalid Customer");
            
            // Validate LegalDocumentId
            var existingLegalDocument = _legalDocumentRepository.FindByIdAsync(legalAdvice.LegalDocumentId);
            
            if (existingLegalDocument == null)
                return new LegalAdviceResponse("Invalid Legal Document");

            existingLegalAdvice.Description = legalAdvice.Description;
            existingLegalAdvice.StatusLawService = legalAdvice.StatusLawService;

            try
            {
                _legalAdviceRepository.Update(existingLegalAdvice);
                await _unitOfWork.CompleteAsync();

                return new LegalAdviceResponse(existingLegalAdvice);
            }
            catch (Exception e)
            {
                return new LegalAdviceResponse($"An error occurred while updating the Legal Advice: {e.Message}");
            }
        }
    }
}