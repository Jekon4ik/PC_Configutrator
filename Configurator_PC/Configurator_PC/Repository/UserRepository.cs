using Configurator_PC.Data;
using Configurator_PC.Interfaces;
using Configurator_PC.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Configurator_PC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;
        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateUser(User user)
        {
            _dbContext.Add(user);
            return Save();
        }

        public ICollection<Configuration> GetConfugirations(int userId)
        {
            return _dbContext.Configurations
                .Where(c => c.UserId == userId)
                .Include(c => c.ConfigurationComponents)
                    .ThenInclude(cc => cc.Component)
                .ToList();
        }

        public User GetUser(int userId)
        {
            return _dbContext.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public User GetUser(string login)
        {
            return _dbContext.Users.Where(u => u.Login == login).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _dbContext.Users.OrderBy(u=> u.Id).ToList();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExist(int userId)
        {
            return _dbContext.Users.Any(u => u.Id == userId);
        }
    }
}
