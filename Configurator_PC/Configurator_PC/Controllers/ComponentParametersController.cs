using AutoMapper;
using Configurator_PC.Dtos;
using Configurator_PC.Interfaces;
using Configurator_PC.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Configurator_PC.Controllers
{
    [Route("configurator/[controller]")]
    [ApiController]
    public class ComponentParametersController : ControllerBase
    {
        private readonly IComponentParameterRepository _componentParameterRepository;
        private readonly IMapper _mapper;
        public ComponentParametersController(IComponentParameterRepository componentParameterRepository, IMapper mapper)
        {
            _componentParameterRepository = componentParameterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComponentParameters()
        {
            var componentParameters = _mapper.Map<List<ComponentParameterDto>>(_componentParameterRepository
                .GetComponentParameters());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(componentParameters);
        }
        [HttpGet("{componentParameterId}")]
        public IActionResult GetComponentParameter(int componentParameterId)
        {
            if (!_componentParameterRepository.ComponentParameterExist(componentParameterId))
                return NotFound();
            var componentParameter = _mapper.Map<ComponentParameterDto>(_componentParameterRepository.GetComponentParameter(componentParameterId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(componentParameter);
        }

    }
}
