using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Services;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;

namespace Legiz.Back_End.UserProfileBC.Services
{
    public class LawyerService : ILawyerService
    {
        private readonly ILawyerRepository _lawyerRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        
        public LawyerService(ILawyerRepository lawyerRepository, IUnitOfWork unitOfWork)
        {
            _lawyerRepository = lawyerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Lawyer>> ListAsync()
        {
            return await _lawyerRepository.ListAsync();
        }

        public async Task<LawyerResponse> GetByIdAsync(int id)
        {
            var existingLawyer = await _lawyerRepository.FindByIdAsync(id);

            if (existingLawyer == null)
                return new LawyerResponse("Lawyer not found.");

            try
            {
                await _unitOfWork.CompleteAsync();

                return new LawyerResponse(existingLawyer);
            }
            catch (Exception e)
            {
                return new LawyerResponse($"An error occurred while finding the Lawyer: {e.Message}");
            }

        }

        public async Task<LawyerResponse> SaveAsync(Lawyer lawyer)
        {
            try
            {
                await _lawyerRepository.AddAsync(lawyer);
                await _unitOfWork.CompleteAsync();

                return new LawyerResponse(lawyer);
            }
            catch (Exception e)
            {
                return new LawyerResponse($"An error occurred while saving the Lawyer: {e.Message}");
            }
        }

        public async Task<LawyerResponse> UpdateAsync(int id, Lawyer lawyer)
        {
            var existingLawyer = await _lawyerRepository.FindByIdAsync(id);

            if (existingLawyer == null)
                return new LawyerResponse("Lawyer not found.");

            existingLawyer.Username = lawyer.Username;
            existingLawyer.Password = lawyer.Password;
            existingLawyer.Email = lawyer.Email;
            existingLawyer.LawyerName = lawyer.LawyerName;
            existingLawyer.LawyerLastName = lawyer.LawyerLastName;
            existingLawyer.District = lawyer.District;
            existingLawyer.Phone = lawyer.Phone;
            existingLawyer.Specialization = lawyer.Specialization;
            existingLawyer.University = lawyer.University;
            existingLawyer.PriceCustomContract = lawyer.PriceCustomContract;
            existingLawyer.PriceLegalAdvice = lawyer.PriceLegalAdvice;

            try
            {
                _lawyerRepository.Update(existingLawyer);
                await _unitOfWork.CompleteAsync();

                return new LawyerResponse(existingLawyer);
            }
            catch (Exception e)
            {
                return new LawyerResponse($"An error occurred while updating the Lawyer: {e.Message}");
            }
            
        }

        public async Task<LawyerResponse> DeleteAsync(int id)
        {
            var existingLawyer = await _lawyerRepository.FindByIdAsync(id);

            if (existingLawyer == null)
                return new LawyerResponse("Lawyer not found.");

            try
            {
                _lawyerRepository.Remove(existingLawyer);
                await _unitOfWork.CompleteAsync();

                return new LawyerResponse(existingLawyer);
            }
            catch (Exception e)
            {
                return new LawyerResponse($"An error occurred while deleting the Lawyer: {e.Message}");
            }
        }
    }
}