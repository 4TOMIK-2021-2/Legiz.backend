using AutoMapper;
using Legiz.Back_End.UserProfileBC.Domain.Models;
using Legiz.Back_End.UserProfileBC.Resources;

namespace Legiz.Back_End.UserProfileBC.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Lawyer, LawyerResource>()
                .ForMember(target => target.Specialization,
                    options => options.MapFrom(source => source.Specialization));
        }
    }
}