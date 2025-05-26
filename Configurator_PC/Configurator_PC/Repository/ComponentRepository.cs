using Configurator_PC.Data;
using Configurator_PC.Dtos;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Configurator_PC.Repository
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly DataContext _dbContext;

        public ComponentRepository(DataContext context)
        {
            _dbContext = context;
        }

        public bool ComponentExist(int id)
        {
            return _dbContext.Components.Any(c => c.Id == id);
        }

        public Component GetComponent(int id)
        {
            return _dbContext.Components.Where(c => c.Id == id).FirstOrDefault();
        }

        public Component GetComponent(string name)
        {
            return _dbContext.Components.Where(c=> c.Name == name).FirstOrDefault();
        }

        public ICollection<Component> GetComponents()
        {
            return _dbContext.Components.OrderBy(p=> p.Id).ToList();
        }

        public async Task<ICollection<MotherboardDto>> GetMotherboardsAsync()
        {
            var motherboardType = await _dbContext.ComponentTypes
                .FirstOrDefaultAsync(m => m.Id == 1);

            if (motherboardType == null)
                return null;

            var motherboards = await _dbContext.Components
                .Include(c => c.Parameters)
                .ThenInclude(p => p.ParameterName)
                .ToListAsync();

            var dtos = motherboards.Select(c => new MotherboardDto
            {
                Id = c.Id,
                Name = c.Name,
                TypeId = c.TypeId,
                Price = c.Price,
                ImageUrl = c.ImageUrl,

                Socket = GetParameterValue(c, "Socket"),
                FormFactor = GetParameterValue(c, "FormFactor"),
                SupportedMemoryType = GetParameterValue(c, "SupportedMemoryType"),
                MemorySlots = ParseIntParameter(c, "MemorySlots"),
                M2Slots = ParseIntParameter(c, "M2Slots"),
                SataPorts = ParseIntParameter(c, "SataPorts")
            }).ToList();

            return dtos;
        }

        private static string GetParameterValue(Component component, string parameterName)
        {
            return component.Parameters?
                .FirstOrDefault(p => p.ParameterName.Name == parameterName)
                .Value ?? string.Empty;
        }

        private static int ParseIntParameter(Component component, string parameterName)
        {
            var value = GetParameterValue(component, parameterName);
            return int.TryParse(value, out var result) ? result : 0;
        }

        public async Task<ICollection<DynamicComponentDto>> GetDynamicComponents(int componentTypeId)
        {
            var type = await _dbContext.ComponentTypes.FirstOrDefaultAsync(c=> c.Id == componentTypeId);

            if (type == null)
                return new List<DynamicComponentDto>();

            var components = await _dbContext.Components
                .Include(c => c.Parameters)
                    .ThenInclude(p => p.ParameterName)
                .Where(c => c.TypeId == type.Id)
                .ToListAsync();

            var dtos = components.Select(c => new DynamicComponentDto
            {
                Id = c.Id,
                Name = c.Name,
                TypeId = c.TypeId,
                Price = c.Price,
                ImageUrl = c.ImageUrl,
                Parameters = c.Parameters?
                    .Where(p => p.ParameterName != null)
                    .ToDictionary(
                        p => p.ParameterName!.Name,
                        p => p.Value ?? string.Empty
                    ) ?? new Dictionary<string, string>()
            }).ToList(); 

            return dtos;
        }
        
    }
}
