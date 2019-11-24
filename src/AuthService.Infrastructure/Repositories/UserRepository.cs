using System.Collections.Generic;
using System.Threading.Tasks;
using AuthService.Core.Models;
using AuthService.Core.Repositories;
using AuthService.Infrastructure.Settings;

namespace AuthService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
		private readonly SqlSettings _sqlSettings;

		public UserRepository(SqlSettings sqlSettings)
		{
			_sqlSettings = sqlSettings;
		}
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