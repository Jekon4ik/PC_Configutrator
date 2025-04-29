using Configurator_PC.Data;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Microsoft.EntityFrameworkCore;

namespace Configurator_PC.Repository
{
    public class ComponentTypeRepository : IComponentTypeRepository
    {
        private readonly DataContext _dbContext;
        public ComponentTypeRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public bool ComponentTypeExist(int id)
        {
            return _dbContext.ComponentTypes.Any(p=>p.Id == id);
        }

        public ComponentType GetComponentType(int id)
        {
            return _dbContext.ComponentTypes.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<ComponentType> GetComponentTypes()
        {
            return _dbContext.ComponentTypes.OrderBy(c=>c.Id).ToList();
        }
        public ICollection<Component> GetComponentByType(int typeId)
        {
            return _dbContext.Components.Where(c=> c.TypeId == typeId).ToList(); 
        }
    }
}
