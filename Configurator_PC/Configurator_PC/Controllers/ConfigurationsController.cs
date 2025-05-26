using AutoMapper;
using Configurator_PC.Data;
using Configurator_PC.Dtos;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Configurator_PC.Profiles;
using Configurator_PC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Configurator_PC.Controllers
{
    [Route("configurator/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMapper _mapper;

        public ConfigurationsController(IConfigurationRepository configurationRepository, IMapper mapper)
        {
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetConfigurations()
        {
            var configurations = _mapper.Map<List<ConfigurationDto>>(_configurationRepository.GetConfigurations());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(configurations);
        }

        [HttpGet("{configurationId}")]
        public IActionResult GetConfiguration(int configurationId)
        {
            if (!_configurationRepository.ConfigurationExist(configurationId))
                return NotFound();

            var configuration = _mapper.Map<ConfigurationDto>(_configurationRepository.GetConfiguration(configurationId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(configuration);
        }

        [HttpGet("Components/{configurationId}")]
        public IActionResult GetComponents(int configurationId)
        {
            var configurationComponents = _mapper.Map<List<ComponentDto>>(
                _configurationRepository.GetComponents(configurationId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(configurationComponents);
        }

        [HttpGet("{configurationId}/SuitableComponentsByType/{typeId}")]
        public IActionResult GetSuitableComponentsByType(int configurationId, int typeId)
        {
            var components = _configurationRepository.GetSuitableComponentsByType(configurationId, typeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dynamicDtos = components
                .Select(ComponentManualMapper.ConvertToDynamicDto)
                .ToList();

            return Ok(dynamicDtos);
        }

        [HttpPost("{configurationId}/add-component/{componentId}")]
        public async Task<IActionResult> AddComponentToConfiguration(int configurationId, int componentId)
        {
            var result = await _configurationRepository.AddComponentToConfigurationAsync(configurationId, componentId);

            if (!result)
                return BadRequest("Failed to add component to configuration.");

            return Ok("Component added successfully.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfiguration([FromBody] string configurationName)
        {
            if (string.IsNullOrWhiteSpace(configurationName))
            {
                return BadRequest("Configuration name is required.");
            }

            var configuration = await _configurationRepository.CreateConfigurationAsync(configurationName);
            return Ok(configuration);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateConfigurationForUser([FromBody] string configurationName, int userId)
        {
            if (string.IsNullOrWhiteSpace(configurationName))
                return BadRequest("Configuration name is required.");

            var configuration = await _configurationRepository.CreateConfigurationForUser(configurationName,userId);
            return Ok(configuration);
        }

        [HttpDelete("{configurationId}")]
        public IActionResult DeleteConfiguration(int configurationId)
        {
            var configuration = _configurationRepository.GetConfiguration(configurationId);
            if (configuration == null)
                return NotFound();
            if (!_configurationRepository.DeleteConfiguration(configuration))
            {
                ModelState.AddModelError("", "Failed to delete configuration.");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{configurationId}/Component/{componentTypeId}")]
        public IActionResult DeleteConfiguration(int configurationId, int componentTypeId)
        {
            var component = _configurationRepository.GetComponents(configurationId)
                .Where(c=> c.TypeId == componentTypeId).FirstOrDefault();
            if (component == null)
                return NotFound();
            if(!_configurationRepository.DeleteComponentFromConfiguration(configurationId, componentTypeId))
            {
                ModelState.AddModelError("", "Failed to delete component from configuration.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
