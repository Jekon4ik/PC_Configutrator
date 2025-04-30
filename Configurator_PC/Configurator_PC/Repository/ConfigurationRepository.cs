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
                Name = configurationName,
                UserId = null
            };

            _dbContext.Configurations.Add(configuration);
            await _dbContext.SaveChangesAsync();

            return configuration;
        }

        public bool CreateConfigurationForUser(string configurationName,int userId)
        {
            var configuration = new Configuration
            {
                Name = configurationName,
                UserId = userId
            };
            _dbContext.Configurations.Add(configuration);
            return Save();
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
            var existingComponents = _dbContext.ConfigurationComponents
                    .Where(cc => cc.ConfigurationId == configurationId)
                    .Include(cc => cc.Component)
                        .ThenInclude(c => c.Type)
                    .Include(cc => cc.Component)
                        .ThenInclude(c => c.Parameters)
                            .ThenInclude(cp => cp.ParameterName)
                    .Select(cc => cc.Component!)
                    .ToList();

            if (!existingComponents.Any())
            {
                return _dbContext.Components
                    .Where(c => c.TypeId == typeId)
                    .Include(c => c.Parameters)
                    .ToList();
            }

            var candidateComponents = _dbContext.Components
                .Where(c => c.TypeId == typeId)
                .Include(c => c.Parameters)
                    .ThenInclude(cp => cp.ParameterName)
                .ToList();

            var compatibleComponents = new List<Component>();

            foreach (var candidate in candidateComponents)
            {
                bool isCompatible = true;

                foreach (var existing in existingComponents)
                {
                    var rules = _dbContext.CompatibilityRules
                        .Where(r =>
                            (r.ComponentType1Id == existing.TypeId && r.ComponentType2Id == typeId) ||
                            (r.ComponentType2Id == existing.TypeId && r.ComponentType1Id == typeId))
                        .Include(r => r.ParameterName)
                        .ToList();

                    foreach (var rule in rules)
                    {
                        var paramNameId = rule.ParameterNameId;

                        var existingParam = existing.Parameters?.FirstOrDefault(p => p.ParameterNameId == paramNameId);
                        var candidateParam = candidate.Parameters?.FirstOrDefault(p => p.ParameterNameId == paramNameId);

                        if (existingParam == null || candidateParam == null)
                        {
                            isCompatible = false;
                            break;
                        }

                        switch (rule.Operator)
                        {
                            case "=":
                                if (existingParam.Value != candidateParam.Value)
                                {
                                    isCompatible = false;
                                }
                                break;
                            default:
                                isCompatible = false;
                                break;
                        }

                        if (!isCompatible)
                            break;
                    }

                    if (!isCompatible)
                        break;
                }

                if (isCompatible)
                {
                    compatibleComponents.Add(candidate);
                }
            }

            return compatibleComponents;
        }

        bool DeleteConfiguration(Configuration configuration)
        {
            _dbContext.Configurations.Remove(configuration);
            _dbContext.ConfigurationComponents
                .RemoveRange(_dbContext.ConfigurationComponents.Where(cc => cc.ConfigurationId == configuration.Id));
            return Save();
        }
        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        bool IConfigurationRepository.DeleteConfiguration(Configuration configuration)
        {
            return DeleteConfiguration(configuration);
        }
    }
}
