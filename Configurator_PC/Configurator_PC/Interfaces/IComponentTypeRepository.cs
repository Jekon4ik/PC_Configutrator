using Configurator_PC.Models;

namespace Configurator_PC.Interfaces
{
    public interface IComponentTypeRepository
    {
        ICollection<ComponentType> GetComponentTypes();
        ComponentType GetComponentType(int id);
        bool ComponentTypeExist(int id);
        ICollection<Component> GetComponentByType(int categoryId);
    }
}
