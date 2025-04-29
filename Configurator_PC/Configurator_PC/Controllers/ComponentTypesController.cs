using AutoMapper;
using Configurator_PC.Dtos;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Configurator_PC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Configurator_PC.Controllers
{
    [Route("configurator/[controller]")]
    [ApiController]
    public class ComponentTypesController : ControllerBase
    {
        private readonly IComponentTypeRepository _componentTypeRepository;
        private readonly IMapper _mapper;
        public ComponentTypesController(IComponentTypeRepository componentTypeRepository, IMapper mapper)
        {
            _componentTypeRepository = componentTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComponentTypes()
        {
            var componentTypes = _mapper.Map<List<ComponentTypeDto>>(_componentTypeRepository.GetComponentTypes());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(componentTypes);
        }

        [HttpGet("{componentTypeId}")]
        public IActionResult GetComponentType(int componentTypeId)
        {
            if (!_componentTypeRepository.ComponentTypeExist(componentTypeId))
                return NotFound();
            var componentType = _mapper.Map<ComponentTypeDto>(
                _componentTypeRepository.GetComponentType(componentTypeId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(componentType);
        }
        [HttpGet("Components/{componentTypeId}")]
        public IActionResult GetComponentByTypeId(int componentTypeId)
        {
            var components = _mapper.Map<List<ComponentDto>>(
                _componentTypeRepository.GetComponentByType(componentTypeId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(components);
        }
    }
}
