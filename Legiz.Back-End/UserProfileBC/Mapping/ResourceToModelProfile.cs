using AutoMapper;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Domain.Services.Communication;
using Legiz.Back_End.UserProfileBC.Resources;

namespace Legiz.Back_End.UserProfileBC.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            // NEW
            CreateMap<RegisterCustomerRequest, Customer>();
            
            CreateMap<UpdateCustomerRequest, Customer>()
                .ForAllMembers(options => options.Condition(
                    (source, target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));
            
            CreateMap<RegisterLawyerRequest, Lawyer>()
                .ForMember(target => target.Specialization,
                    options => options.MapFrom(source => (ESpecialization) source.Specialization));

            CreateMap<UpdateLawyerRequest, Lawyer>()
                .ForMember(target => target.Specialization,
                    options => options.MapFrom(source => (ESpecialization) source.Specialization))
                .ForAllMembers(options => options.Condition(
                    (source, target, property) =>
                    {
                        if (property == null) return false;
                        if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                        return true;
                    }));
            
            // OLD
            CreateMap<SaveSubscriptionResource, Subscription>()
                .ForMember(target => target.State,
                    options => options.MapFrom(source => (EState) source.State));
        }
    }
}