using AutoMapper;
using Configurator_PC.Data;
using Configurator_PC.Dtos;
using Configurator_PC.Interfaces;
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
        private readonly IComponentRepository _componentRepository;
        private readonly IMapper _mapper;

        public ComponentsController(IComponentRepository componentRepository, IMapper mapper)
        {
            _componentRepository = componentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComponents()
        {
            var components = _mapper.Map<List<ComponentDto>>(_componentRepository.GetComponents());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(components);
        }

        [HttpGet("{componentId}")]
        public IActionResult GetComponent(int componentId) 
        {
            if(!_componentRepository.ComponentExist(componentId))
                return NotFound();
            var component = _mapper.Map<ComponentDto>(_componentRepository.GetComponent(componentId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(component);
        }

       

    }   
}
