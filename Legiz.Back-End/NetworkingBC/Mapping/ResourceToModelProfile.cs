using AutoMapper;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Resources;

namespace Legiz.Back_End.NetworkingBC.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveScoreResource, Score>();
        }
    }
}