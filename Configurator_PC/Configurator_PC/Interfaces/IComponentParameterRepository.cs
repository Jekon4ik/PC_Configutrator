using Configurator_PC.Models;

namespace Configurator_PC.Interfaces
{
    public interface IComponentParameterRepository
    {
        ICollection<ComponentParameter> GetComponentParameters();
        ComponentParameter GetComponentParameter(int id);
        bool ComponentParameterExist(int id);
    }
}
