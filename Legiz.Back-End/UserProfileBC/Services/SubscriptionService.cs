using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Legiz.Back_End.Shared.Domain.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Services;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;

namespace Legiz.Back_End.UserProfileBC.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionService(IUnitOfWork unitOfWork, ISubscriptionRepository subscriptionRepository)
        {
            _unitOfWork = unitOfWork;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _subscriptionRepository.ListAsync();
        }

        public async Task<SubscriptionResponse> GetByIdAsync(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindByIdAsync(id);
            
            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found.");

            try
            {
                await _unitOfWork.CompleteAsync();

                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception e)
            {
                return new SubscriptionResponse($"An error occurred while finding the subscription: {e.Message}");
            }
        }

        public async Task<SubscriptionResponse> SaveAsync(Subscription subscription)
        {
            try
            {
                await _subscriptionRepository.AddAsync(subscription);
                await _unitOfWork.CompleteAsync();

                return new SubscriptionResponse(subscription);
            }
            catch (Exception e)
            {
                // Do some logging stuff
                return new SubscriptionResponse($"An error occurred while saving the subscription: {e.Message}");
            }
        }
    }
}