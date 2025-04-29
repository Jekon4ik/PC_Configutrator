using AutoMapper;
using Configurator_PC.Dtos;
using Configurator_PC.Models;

namespace Configurator_PC.Profiles
{
    public class ComponentProfile : Profile
    {
        public ComponentProfile()
        {
            CreateMap<Component, ComponentDto>();
        }
    }
}
