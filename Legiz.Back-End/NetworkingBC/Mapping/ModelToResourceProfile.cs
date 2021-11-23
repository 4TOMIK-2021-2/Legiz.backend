using AutoMapper;
using Legiz.Back_End.NetworkingBC.Domain.Models;
using Legiz.Back_End.NetworkingBC.Resources;

namespace Legiz.Back_End.NetworkingBC.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Score, ScoreResource>();
        }
    }
}