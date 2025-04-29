using Configurator_PC.Data;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Microsoft.EntityFrameworkCore;

namespace Configurator_PC.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly DataContext _dbContext;

        public ConfigurationRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<bool> AddComponentToConfigurationAsync(int configurationId, int componentId)
        {
            var configurationExists = await _dbContext.Configurations.AnyAsync(c => c.Id == configurationId);
            var componentExists = await _dbContext.Components.AnyAsync(c => c.Id == componentId);

            if (!configurationExists || !componentExists)
            {
                return false;
            }

            var alreadyExists = await _dbContext.ConfigurationComponents
                .AnyAsync(cc => cc.ConfigurationId == configurationId && cc.ComponentId == componentId);

            if (alreadyExists)
            {
                return false;
            }

            var configurationComponent = new ConfigurationComponent
            {
                ConfigurationId = configurationId,
                ComponentId = componentId
            };

            await _dbContext.ConfigurationComponents.AddAsync(configurationComponent);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public bool ConfigurationExist(int id)
        {
            return _dbContext.Configurations.Any(c => c.Id == id);
        }

        public async Task<Configuration> CreateConfigurationAsync(string configurationName)
        {
            var configuration = new Configuration
            {
                Name = configurationName
            };

            _dbContext.Configurations.Add(configuration);
            await _dbContext.SaveChangesAsync();

            return configuration;
        }

        public ICollection<Component> GetComponents(int configurationId)
        {
            return _dbContext.ConfigurationComponents
                    .Where(cc => cc.ConfigurationId == configurationId)
                    .Include(cc => cc.Component) 
                    .Select(cc => cc.Component!) 
                    .ToList();
        }

        public Configuration GetConfiguration(int id)
        {
            return _dbContext.Configurations.FirstOrDefault(c => c.Id == id);
        }

        public Configuration GetConfiguration(string name)
        {
            return _dbContext.Configurations.FirstOrDefault(c => c.Name == name);
        }

        public ICollection<Configuration> GetConfigurations()
        {
            return _dbContext.Configurations.OrderBy(p => p.Id).ToList();
        }

        public ICollection<Component> GetSuitableComponentsByType(int configurationId, int typeId)
        {
            // Get all component IDs currently in the configuration
            var configurationComponentIds = _dbContext.ConfigurationComponents
                .Where(cc => cc.ConfigurationId == configurationId)
                .Select(cc => cc.ComponentId)
                .ToList();

            // Get all components of the requested type
            var candidateComponents = _dbContext.Components
                .Where(c => c.TypeId == typeId)
                .ToList();

            var suitableComponents = new List<Component>();

            foreach (var candidate in candidateComponents)
            {
                bool isCompatibleWithAll = true;

                foreach (var existingComponentId in configurationComponentIds)
                {
                    // Check compatibility in both directions
                    var compatibility = _dbContext.Compatibilities.FirstOrDefault(comp =>
                        (comp.Component1Id == candidate.Id && comp.Component2Id == existingComponentId) ||
                        (comp.Component2Id == candidate.Id && comp.Component1Id == existingComponentId));

                    if (compatibility != null && compatibility.IsCompatible == false)
                    {
                        isCompatibleWithAll = false;
                        break;
                    }
                }

                if (isCompatibleWithAll)
                {
                    suitableComponents.Add(candidate);
                }
            }

            return suitableComponents;
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
