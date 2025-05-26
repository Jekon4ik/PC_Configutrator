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
    public static class ComponentManualMapper
    {
        public static DynamicComponentDto ConvertToDynamicDto(Component component)
        {
            if (component == null)
                return null;

            return new DynamicComponentDto
            {
                Id = component.Id,
                Name = component.Name,
                TypeId = component.TypeId,
                Price = component.Price,
                ImageUrl = component.ImageUrl,
                Parameters = component.Parameters?
                    .Where(p => p.ParameterName != null)
                    .ToDictionary(
                        p => p.ParameterName!.Name,
                        p => p.Value ?? string.Empty
                    ) ?? new Dictionary<string, string>()
            };
        }
    }
}
