namespace AuthService.Core.Repositories
{
    public interface IUserRepository
    {
         Task AddAsync(User user);
    }
}