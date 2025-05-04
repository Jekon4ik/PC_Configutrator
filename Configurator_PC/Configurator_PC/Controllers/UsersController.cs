using AutoMapper;
using Configurator_PC.Dtos;
using Configurator_PC.Dtos;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Configurator_PC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Configurator_PC.Controllers
{
    [Route("configurator/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{userId:int}")]
        public IActionResult GetUser(int userId)
        {
            if (!_userRepository.UserExist(userId))
                return NotFound();
            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("{userLogin}")]
        public IActionResult GetUserByLogin(string userLogin)
        {
            var user = _mapper.Map<UserDto>(_userRepository.GetUser(userLogin));
            if (user == null) return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }


        [HttpGet("Configurations/{userId}")]
        public IActionResult GetConfigurations(int userId)
        {
            if(!_userRepository.UserExist(userId))
                return NotFound();

            var configurations = _userRepository.GetConfugirations(userId);
            if (configurations == null)
                return NotFound($"No configurations found for user ID {userId}.");

            return Ok(configurations);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            if(userCreate == null)
                return BadRequest(ModelState);
            var users = _userRepository.GetUsers().Where(u=>u.Login == userCreate.Login).FirstOrDefault();

            if(users != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("","Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok(userMap);
        }
    }
}
