using System.Threading.Tasks;
using AuthService.Core.Models;

namespace AuthService.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task AddNewAsync(User user);
    }
}