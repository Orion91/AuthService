namespace AuthService.Application.Services
{
    public interface IPasswordService
    {
         bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
         void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}