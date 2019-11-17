using AuthService.Core.Models;
using AuthService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Infrastructure.Repositories
{
	public class InMemoryUserRepository : IUserRepository
	{
		public IEnumerable<User> Users { get; private set; }
		public InMemoryUserRepository()
		{
			Users = Enumerable.Empty<User>();
		}
		public async Task AddAsync(User user)
		{
			Users.Append(user);
		}

		public async Task<User> GetAsync(string username)
		{
			return Users.FirstOrDefault(u => u.Username == username);
		}
	}
}
