using System.Threading.Tasks;

namespace AuthService.Application.Services
{
    public interface IUserService
    {
         Task<bool> UserExistsAsync(string username);
    }
}