using AuthService.Application.Commands;
using System.Threading.Tasks;

namespace AuthService.Application.CQRS
{
    public interface ICommandDispatcher
    {
         Task DispatchAsync<T>(T command) where T : ICommand;
    }
}