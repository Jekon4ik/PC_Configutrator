using AutoMapper;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Configurator_PC.Controllers
{
    [Route("configurator/[controller]")]
    [ApiController]
    public class ConfigurationComponentsController : ControllerBase
    {
        private readonly IConfigurationComponentRepository _configurationComponentRepository;
        private readonly IMapper _mapper;
        public ConfigurationComponentsController(IConfigurationComponentRepository configurationComponentRepository,
            IMapper mapper)
        {
            _configurationComponentRepository = configurationComponentRepository;
            _mapper = mapper;
        }
    }
}
