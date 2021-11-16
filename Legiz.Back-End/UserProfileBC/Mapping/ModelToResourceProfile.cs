using AutoMapper;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Resources;

namespace Legiz.Back_End.UserProfileBC.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Customer, CustomerResource>();
            
            CreateMap<Lawyer, LawyerResource>()
                .ForMember(target => target.Specialization,
                    options => options.MapFrom(source => source.Specialization));
            
            CreateMap<Lawyer,LawyerSubscriptionResource>()
                .ForMember(target => target.Specialization,
                    options => options.MapFrom(source => source.Specialization));

            CreateMap<Subscription, SubscriptionResource>()
                .ForMember(target => target.State,
                    options => options.MapFrom(source => source.State));
        }
    }
}