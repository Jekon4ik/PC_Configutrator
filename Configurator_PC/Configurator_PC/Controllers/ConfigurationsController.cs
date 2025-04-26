using AutoMapper;
using Configurator_PC.Data;
using Configurator_PC.Dtos.ConfigurationDto;
using Configurator_PC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Configurator_PC.Controllers
{
    [Route("configurator/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ConfigurationsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateConfigurationDto>> CreateConfiguration(CreateConfigurationDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest("Configuration name is required.");
            }
            var config = new Configuration { Name = dto.Name };
            _context.Configurations.Add(config);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateConfiguration), new { id = config.Id }, _mapper.Map<Configuration>(config));
        }

        [HttpGet("{configurationId}/available-components/{typeId}")]
        public async Task<ActionResult<List<Component>>> GetAvailableComponents(int configurationId, int typeId)
        {
            var selectedComponentIds = await _context.ConfigurationComponents
                .Where(cc => cc.ConfigurationId == configurationId)
                .Select(cc => cc.ComponentId)
                .ToListAsync();

            List<Component> availableComponents;

            if (!selectedComponentIds.Any())
            {
                availableComponents = await _context.Components
                    .Where(c => c.TypeId == typeId)
                    .ToListAsync();
            }
            else
            {
                availableComponents = await _context.Components
                    .Where(c => c.TypeId == typeId)
                    .Where(c => _context.Compatibilities
                        .Any(comp => selectedComponentIds.Contains(comp.Component1Id) &&
                                     comp.IsCompatible == true &&
                                     comp.Component2Id == c.Id))
                    .ToListAsync();
            }

            return Ok(availableComponents);
        }

        [HttpGet("{configurationId}/components")]
        public async Task<ActionResult<List<Component>>> GetComponentsInConfiguration(int configurationId)
        {
            var configurationResult = await GetConfigurationById(configurationId);
            if (configurationResult.Result is NotFoundObjectResult)
            {
                return NotFound($"Configuration with ID {configurationId} not found.");
            }

            var components = await _context.ConfigurationComponents
                .Where(cc => cc.ConfigurationId == configurationId)
                .Select(cc => cc.Component)
                .ToListAsync();

            if (components == null || !components.Any())
            {
                return NotFound($"No components found for configuration with ID {configurationId}.");
            }

            return Ok(components);
        }

        [HttpGet]
        public async Task<ActionResult<List<Configuration>>> GetAllConfigurations()
        {
            var configurations = await _context.Configurations.ToListAsync();

            if (!configurations.Any())
            {
                return NotFound("No configurations found.");
            }

            return Ok(configurations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Configuration>> GetConfigurationById(int id)
        {
            var configuration = await _context.Configurations.FindAsync(id);

            if (configuration == null)
            {
                return NotFound($"Configuration with ID {id} not found.");
            }

            return Ok(configuration);
        }
        
        [HttpPost("{configurationId}/components")]
        public async Task<ActionResult> AddComponentsToConfiguration(int configurationId, [FromBody] List<int> componentIds)
        {
            var configuration = await _context.Configurations.FindAsync(configurationId);
            if (configuration == null)
            {
                return NotFound($"Configuration with ID {configurationId} not found.");
            }

            var existingComponents = await _context.Components
                .Where(c => componentIds.Contains(c.Id))
                .Select(c => c.Id)
                .ToListAsync();

            var invalidComponentIds = componentIds.Except(existingComponents).ToList();
            if (invalidComponentIds.Any())
            {
                return BadRequest($"The following component IDs are invalid: {string.Join(", ", invalidComponentIds)}");
            }

            var addedComponentIds = await _context.ConfigurationComponents
                .Where(cc => cc.ConfigurationId == configurationId)
                .Select(cc => cc.ComponentId)
                .ToListAsync();

            var incompatibleComponents = new List<int>();
            foreach (var newComponentId in componentIds)
            {
                var isCompatible = await _context.Compatibilities
                    .Where(comp => addedComponentIds.Contains(comp.Component1Id) && comp.Component2Id == newComponentId)
                    .AllAsync(comp => comp.IsCompatible == true);

                if (!isCompatible)
                {
                    incompatibleComponents.Add(newComponentId);
                }
            }

            if (incompatibleComponents.Any())
            {
                return BadRequest($"The following components are incompatible with the configuration: {string.Join(", ", incompatibleComponents)}");
            }

            var configurationComponents = componentIds.Select(componentId => new ConfigurationComponent
            {
                ConfigurationId = configurationId,
                ComponentId = componentId
            });

            _context.ConfigurationComponents.AddRange(configurationComponents);
            await _context.SaveChangesAsync();

            return Ok($"Components successfully added to configuration with ID {configurationId}.");
        }

    }
}
