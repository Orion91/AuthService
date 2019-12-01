using AuthService.Application.Commands;
using AuthService.Application.DTO;
using System.Threading.Tasks;

namespace AuthService.Application.Services.Interfaces
{
    public interface IUserService
    {
		Task<JwtDto> SignInAsync(SignIn command);
        Task SignUpAsync(string username, string password, string email = "");
        Task<bool> UserExistsAsync(string username);
    }
}