using AuthService.Application.Services;

namespace AuthService.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            throw new System.NotImplementedException();
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            throw new System.NotImplementedException();
        }
    }
}