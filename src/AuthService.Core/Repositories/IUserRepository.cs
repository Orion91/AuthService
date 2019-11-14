using System.Threading.Tasks;
using AuthService.Core.Models;

namespace AuthService.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string username);
        Task AddAsync(User user);
    }
}