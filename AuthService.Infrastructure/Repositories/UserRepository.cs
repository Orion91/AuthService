using System.Collections.Generic;
using System.Threading.Tasks;
using AuthService.Core.Models;
using AuthService.Core.Repositories;

namespace AuthService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>();
        public Task AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetAsync(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}