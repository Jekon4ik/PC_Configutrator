using Configurator_PC.Models;

namespace Configurator_PC.Interfaces
{
    public interface IComponentRepository
    {
        ICollection<Component> GetComponents();
        Component GetComponent(int id);
        Component GetComponent(string name);
        bool ComponentExist(int id);

    }
}
