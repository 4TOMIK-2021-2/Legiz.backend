using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Domain.Repositories;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Domain.Repository;
using Legiz.Back_End.NetworkingBC.Domain.Services;
using Legiz.Back_End.NetworkingBC.Domain.Services.Communication;
using Legiz.Back_End.Shared.Domain.Repositories;

namespace Legiz.Back_End.NetworkingBC.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly ICustomLegalCaseRepository _customLegalCaseRepository;
        private readonly ILegalAdviceRepository _legalAdviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ScoreService(IScoreRepository scoreRepository, ICustomLegalCaseRepository customLegalCaseRepository, ILegalAdviceRepository legalAdviceRepository, IUnitOfWork unitOfWork)
        {
            _scoreRepository = scoreRepository;
            _customLegalCaseRepository = customLegalCaseRepository;
            _legalAdviceRepository = legalAdviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Score>> ListAsync()
        {
            return await _scoreRepository.ListAsync();
        }

        public async Task<ScoreResponse> FindByIdAsync(int id)
        {
            var existingScore = await _scoreRepository.FindByIdAsync(id);
            
            if (existingScore == null)
            {
                return new ScoreResponse("Score not found");
            }

            try
            {
                await _unitOfWork.CompleteAsync();

                return new ScoreResponse(existingScore);
            }
            catch (Exception e)
            {
                return new ScoreResponse($"An error occurred while finding the Score: {e.Message}");
            }
            
        }

        public async Task<ScoreResponse> SaveAsync(Score score)
        {
            var existingCustomLegalCase = _customLegalCaseRepository.FindByIdAsync(score.CustomLegalCaseId);
            var existingLegalAdvice = _legalAdviceRepository.FindByIdAsync(score.LegalAdviceId);

            if (existingCustomLegalCase == null & existingLegalAdvice == null)
            {
                return new ScoreResponse("Invalid Custom Legal Case and Invalid Legal Advice");
            }
            
            try
            {
                await _scoreRepository.AddAsync(score);
                await _unitOfWork.CompleteAsync();

                return new ScoreResponse(score);
            }
            catch (Exception e)
            {
                return new ScoreResponse($"An error occurred while saving the Score: {e.Message}");
            }
            
        }
    }
}