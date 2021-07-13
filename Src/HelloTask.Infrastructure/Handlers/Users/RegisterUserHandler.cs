using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Users;
using HelloTask.Infrastructure.Services;

namespace HelloTask.Infrastructure.Handlers.Users
{
    public class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserService _userService;

        public RegisterUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(RegisterUserCommand command)
        {
            await _userService.RegisterUserAsync(Guid.NewGuid(), command.Email,
                command.Username, command.Password, command.Role);
        }
    }
}
