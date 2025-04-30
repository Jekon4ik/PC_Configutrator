using Configurator_PC.Models;

namespace Configurator_PC.Interfaces
{
    public interface IConfigurationRepository
    {
        ICollection<Configuration> GetConfigurations();
        Configuration GetConfiguration(int id);
        Configuration GetConfiguration(string name);
        bool ConfigurationExist(int id);
        ICollection<Component> GetSuitableComponentsByType(int configurationId, int typeId);
        ICollection<Component> GetComponents(int id);
        Task<bool> AddComponentToConfigurationAsync(int configurationId, int componentId);
        Task<Configuration> CreateConfigurationAsync(string configurationName);
        bool CreateConfigurationForUser(string configurationName, int userId);
        bool DeleteConfiguration(Configuration configuration);
        bool Save();
    }
}
