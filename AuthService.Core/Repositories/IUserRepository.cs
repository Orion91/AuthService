using System.Threading.Tasks;
using AuthService.Core.Entities;

namespace AuthService.Core.Repositories
{
    public interface IUserRepository
    {
         Task AddAsync(User user);
    }
}