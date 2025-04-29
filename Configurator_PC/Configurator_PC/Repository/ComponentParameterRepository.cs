using Configurator_PC.Data;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Microsoft.EntityFrameworkCore;

namespace Configurator_PC.Repository
{
    public class ComponentParameterRepository : IComponentParameterRepository
    {
        private readonly DataContext _dbContext;
        public ComponentParameterRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public bool ComponentParameterExist(int id)
        {
            return _dbContext.ComponentParameters.Any(c => c.Id == id);
        }

        public ComponentParameter GetComponentParameter(int id)
        {
            return _dbContext.ComponentParameters.Where(p => p.Id == id).FirstOrDefault();
        }

        public ICollection<ComponentParameter> GetComponentParameters()
        {
            return _dbContext.ComponentParameters.OrderBy(p => p.Id).ToList();
        }
    }
}
