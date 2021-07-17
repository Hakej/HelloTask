using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Users;
using HelloTask.Infrastructure.Services;

namespace HelloTask.Infrastructure.Handlers.Users
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;
        
        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(DeleteUserCommand command)
        {
            await _userService.DeleteAsync(command.UserId);
        }
    }
}