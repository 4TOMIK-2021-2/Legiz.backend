using AutoMapper;
using Legiz.Back_End.SecurityBC.Domain.Models;
using Legiz.Back_End.SecurityBC.Domain.Services.Communication;
using Legiz.Back_End.SecurityBC.Resources;

namespace Legiz.Back_End.SecurityBC.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();

            CreateMap<User, AuthenticateResponse>();
        }
    }
}