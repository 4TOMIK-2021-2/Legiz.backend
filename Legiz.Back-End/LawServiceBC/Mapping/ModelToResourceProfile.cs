using AutoMapper;
using Legiz.Back_End.LawServiceBC.Domain.Models;
using Legiz.Back_End.LawServiceBC.Resources;

namespace Legiz.Back_End.LawServiceBC.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<CustomLegalCase, CustomLegalCaseResource>()
                .ForMember(target => target.TypeMeet, 
                    options => options.MapFrom(source => source.TypeMeet))
                .ForMember(target => target.StatusLawService,
                    options => options.MapFrom(source => source.StatusLawService));
            
            CreateMap<LegalAdvice, LegalAdviceResource>()
                .ForMember(target => target.StatusLawService,
                    options => options.MapFrom(source => source.StatusLawService));

            CreateMap<LegalDocument, LegalDocumentResource>();
        }
    }
}