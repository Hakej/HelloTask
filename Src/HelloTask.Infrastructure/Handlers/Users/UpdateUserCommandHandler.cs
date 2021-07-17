using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Users;
using HelloTask.Infrastructure.Services;

namespace HelloTask.Infrastructure.Handlers.Users  
{
    public class UpdateUserCommandHandler: ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(UpdateUserCommand command)
        {
            await _userService.ChangeUsername(command.UserId, command.NewUsername);
        }
    }
}