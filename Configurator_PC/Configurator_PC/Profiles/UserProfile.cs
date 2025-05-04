using AutoMapper;
using Configurator_PC.Dtos;
using Configurator_PC.Models;

namespace Configurator_PC.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
