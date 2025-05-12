using AutoMapper;
using Configurator_PC.Dtos;
using Configurator_PC.Models;

namespace Configurator_PC.Profiles
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Configuration, ConfigurationDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForSourceMember(src => src.ConfigurationComponents, opt => opt.DoNotValidate());
            CreateMap<ConfigurationDto, Configuration>();
        }
    }
}
