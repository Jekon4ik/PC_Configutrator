using Configurator_PC.Models;
using System.ComponentModel;

namespace Configurator_PC.Interfaces
{
    public interface IConfigurationComponentRepository
    {
        bool CreateConfigurationComponent(int configurationId, int componentId);
        bool Save();
    }
}
