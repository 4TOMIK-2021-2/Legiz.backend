using AutoMapper;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Resources;

namespace Legiz.Back_End.UserProfileBC.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveLawyerResource, Lawyer>()
                .ForMember(target => target.Specialization,
                    options => options.MapFrom(source => (ESpecialization) source.Specialization));
        }
    }
}