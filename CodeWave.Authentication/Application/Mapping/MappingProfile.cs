using CodeWave.Authentication.Domain.Dto;
using AutoMapper;
using CodeWave.Authentication.Domain.Entities;

namespace CodeWave.Authentication.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, IdentityUser>();
            CreateMap<LoginUserDto, IdentityUser>();
        }
    }
}
