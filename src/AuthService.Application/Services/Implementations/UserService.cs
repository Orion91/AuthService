using System;
using System.Threading.Tasks;
using AuthService.Application.Services.Interfaces;
using AuthService.Core.Models;
using AuthService.Core.Repositories;

namespace AuthService.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task SignUpAsync(string username, string password, string email = "")
        {
            if(await UserExistsAsync(username))
            {
                throw new Exception($"User with username: {username} already exists");
            }

            byte[] passwordHash, passwordSalt;
            _passwordService.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var userToCreate = new User(username, email, passwordHash, passwordSalt);
            await _userRepository.AddNewAsync(userToCreate);
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            var userFromRepo = await _userRepository.GetUserByUsernameAsync(username);
            if(userFromRepo is null)
                return false;
            return true;
        }
    }
}