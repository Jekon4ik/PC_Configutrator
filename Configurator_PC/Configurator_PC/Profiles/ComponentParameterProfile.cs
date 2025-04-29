using AutoMapper;
using Configurator_PC.Dtos;
using Configurator_PC.Models;

namespace Configurator_PC.Profiles
{
    public class ComponentParameterProfile : Profile
    {
        public ComponentParameterProfile()
        {
            CreateMap<ComponentParameter, ComponentParameterDto>();
        }
    }
}
