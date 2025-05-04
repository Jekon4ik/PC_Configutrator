using Configurator_PC.Models;

namespace Configurator_PC.Interfaces
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public User GetUser(int userId); 
        public User GetUser(string login);
        public bool UserExist(int userId);
        public ICollection<Configuration> GetConfugirations(int userId);
        public bool CreateUser(User user);
        public bool Save();
    }
}
