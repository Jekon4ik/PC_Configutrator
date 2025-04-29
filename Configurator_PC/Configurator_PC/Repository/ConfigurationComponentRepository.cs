using Configurator_PC.Data;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;

namespace Configurator_PC.Repository
{
    public class ConfigurationComponentRepository : IConfigurationComponentRepository
    {
        private readonly DataContext _dbContext;

        public ConfigurationComponentRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateConfigurationComponent(int configurationId, int componentId)
        {
            var configurationComponent = new ConfigurationComponent
            {
                ConfigurationId = configurationId,
                ComponentId = componentId
            };

            _dbContext.ConfigurationComponents.Add(configurationComponent);
            return Save();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
