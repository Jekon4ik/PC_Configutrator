using AutoMapper;
using Configurator_PC.Dtos.ConfigurationDto;
using Configurator_PC.Models;

namespace Configurator_PC.Profiles
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Configuration, CreateConfigurationDto>();
        }
    }
}
