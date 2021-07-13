﻿using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Account;
using HelloTask.Infrastructure.Extensions;
using HelloTask.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace HelloTask.Infrastructure.Handlers.Account
{
    public class LoginHandler : ICommandHandler<LoginCommand>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(LoginCommand command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetUserByEmailAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(command.Email, user.Role);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}
