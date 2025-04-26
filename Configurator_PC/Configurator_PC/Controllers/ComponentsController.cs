using Configurator_PC.Data;
using Configurator_PC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Configurator_PC.Controllers
{
    [Route("configurator/[controller]")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ComponentsController(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            return await _dataContext.Components
                .Include(c => c.Type)
                .Include(c => c.Parameters)
                .Include(c => c.ConfigurationComponents)
                .ToListAsync();       
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Component>> GetComponent(int id)
        {
            var component = await _dataContext.Components.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }
            return component;
        }

        [HttpPost]
        public async Task<ActionResult<Component>> PostComponent(Component component)
        {
            _dataContext.Components.Add(component);
            await _dataContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComponent), new { id = component.Id }, component);
        }

    }   
}
