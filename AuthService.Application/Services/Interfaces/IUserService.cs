using System.Threading.Tasks;

namespace AuthService.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task SignUpAsync(string username, string password, string email = "");
        Task<bool> UserExistsAsync(string username);
    }
}