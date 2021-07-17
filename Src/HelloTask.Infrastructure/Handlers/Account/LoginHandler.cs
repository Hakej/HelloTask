using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Account;
using HelloTask.Infrastructure.Extensions;
using HelloTask.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace HelloTask.Infrastructure.Handlers.Account
{
    public class LoginHandler : ICommandHandler<LoginCommand>
    {
        private readonly IHandler _handler;
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IHandler handler, IUserService userService,
            IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _handler = handler;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(LoginCommand command)
            => await _handler
                .Run(async () => await _userService.LoginAsync(command.Email, command.Password))
                .Next()
                .Run(async () =>
                {
                    var user = await _userService.GetUserByEmailAsync(command.Email);
                    var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
                    _cache.SetJwt(command.TokenId, jwt);
                })
                .ExecuteAsync();
    }
}
