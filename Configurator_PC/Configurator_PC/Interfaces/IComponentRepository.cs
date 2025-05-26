using Configurator_PC.Dtos;
using Configurator_PC.Models;

namespace Configurator_PC.Interfaces
{
    public interface IComponentRepository
    {
        ICollection<Component> GetComponents();
        Component GetComponent(int id);
        Component GetComponent(string name);
        Task<ICollection<MotherboardDto>> GetMotherboardsAsync();
        Task<ICollection<DynamicComponentDto>> GetDynamicComponents(int componentTypeId);
        bool ComponentExist(int id);

    }
}
