using Configurator_PC.Data;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using System.Xml.Linq;

namespace Configurator_PC.Repository
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly DataContext _dbContext;

        public ComponentRepository(DataContext context)
        {
            _dbContext = context;
        }

        public bool ComponentExist(int id)
        {
            return _dbContext.Components.Any(c => c.Id == id);
        }

        public Component GetComponent(int id)
        {
            return _dbContext.Components.Where(c => c.Id == id).FirstOrDefault();
        }

        public Component GetComponent(string name)
        {
            return _dbContext.Components.Where(c=> c.Name == name).FirstOrDefault();
        }

        public ICollection<Component> GetComponents()
        {
            return _dbContext.Components.OrderBy(p=> p.Id).ToList();
        }
    }
}
