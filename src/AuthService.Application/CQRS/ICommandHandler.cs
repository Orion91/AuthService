using System.Threading.Tasks;

namespace AuthService.Application.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task HandleAsync(T command);
    }
}