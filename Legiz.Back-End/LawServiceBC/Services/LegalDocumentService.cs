using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Domain.Repositories;
using Legiz.Back_End.LawServiceBC.Domain.Services;
using Legiz.Back_End.LawServiceBC.Domain.Services.Communication;
using Legiz.Back_End.Shared.Domain.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;

namespace Legiz.Back_End.LawServiceBC.Services
{
    public class LegalDocumentService : ILegalDocumentService
    {
        private readonly ILegalDocumentRepository _legalDocumentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LegalDocumentService(IUnitOfWork unitOfWork, ILegalDocumentRepository legalDocumentRepository)
        {
            _unitOfWork = unitOfWork;
            _legalDocumentRepository = legalDocumentRepository;
        }

        public async Task<IEnumerable<LegalDocument>> ListAsync()
        {
            return await _legalDocumentRepository.ListAsync();
        }

        public async Task<LegalDocumentResponse> GetByIdAsync(int id)
        {
            var existingLegalDocument = await _legalDocumentRepository.FindByIdAsync(id);

            if (existingLegalDocument == null)
                return new LegalDocumentResponse("Legal Document not found.");

            try
            {
                await _unitOfWork.CompleteAsync();

                return new LegalDocumentResponse(existingLegalDocument);
            }
            catch (Exception e)
            {
                return new LegalDocumentResponse($"An error occurred while finding the Legal Document: {e.Message}");
            }
        }

        public async Task<LegalDocumentResponse> SaveAsync(LegalDocument legalDocument)
        {
            try
            {
                await _legalDocumentRepository.AddAsync(legalDocument);
                await _unitOfWork.CompleteAsync();

                return new LegalDocumentResponse(legalDocument);
            }
            catch (Exception e)
            {
                return new LegalDocumentResponse($"An error occurred while saving the Legal Document: {e.Message}");
            }
        }

        public async Task<LegalDocumentResponse> UpdateAsync(int id, LegalDocument legalDocument)
        {
            var existingLegalDocument = await _legalDocumentRepository.FindByIdAsync(id);

            if (existingLegalDocument == null)
                return new LegalDocumentResponse("Legal Document not found.");

            existingLegalDocument.DocumentTitle = legalDocument.DocumentTitle;
            existingLegalDocument.Path = legalDocument.Path;
            
            try
            {
                _legalDocumentRepository.Update(existingLegalDocument);
                await _unitOfWork.CompleteAsync();

                return new LegalDocumentResponse(existingLegalDocument);
            }
            catch (Exception e)
            {
                return new LegalDocumentResponse($"An error occurred while updating the Legal Document: {e.Message}");
            }
        }

        public async Task<LegalDocumentResponse> DeleteAsync(int id)
        {
            var existingLegalDocument = await _legalDocumentRepository.FindByIdAsync(id);

            if (existingLegalDocument == null)
                return new LegalDocumentResponse("Legal Document not found.");

            try
            {
                _legalDocumentRepository.Remove(existingLegalDocument);
                await _unitOfWork.CompleteAsync();

                return new LegalDocumentResponse(existingLegalDocument);
            }
            catch (Exception e)
            {
                return new LegalDocumentResponse($"An error occurred while deleting the Legal Document: {e.Message}");
            }
        }
    }
}