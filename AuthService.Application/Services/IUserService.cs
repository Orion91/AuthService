using System.Threading.Tasks;

namespace AuthService.Application.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string username, string password, string email = "");
        Task<bool> UserExistsAsync(string username);
    }
}