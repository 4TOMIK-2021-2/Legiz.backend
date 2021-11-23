using AutoMapper;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Resources;

namespace Legiz.Back_End.LawServiceBC.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCustomLegalCaseResource, CustomLegalCase>()
                .ForMember(target => target.TypeMeet,
                    options => options.MapFrom(source => (ETypeMeet) source.TypeMeet))
                .ForMember(target => target.StatusLawService,
                options => options.MapFrom(source => (EStatusLawService) source.StatusLawService));

            CreateMap<SaveLegalAdviceResource, LegalAdvice>()
                .ForMember(target => target.StatusLawService,
                    options => options.MapFrom(source => (EStatusLawService) source.StatusLawService));

            CreateMap<SaveLegalDocumentResource, LegalDocument>();
        }
    }
}