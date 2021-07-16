using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Users;
using HelloTask.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HelloTask.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        private readonly IUserService _userService;

        public UsersController(IUserService userService, 
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Logger.Info("Fetching users.");
            
            var users = await _userService.GetAllUsersAsync();

            return Json(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpGet("WithEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserCommand command)
        {
            await DispatchAsync(command);

            return Created("users/", new object());
        }

        [Authorize]
        [HttpDelete("me")]
        public async Task<IActionResult> Delete()
        {
            await DispatchAsync(new DeleteUserCommand());

            return NoContent();
        }
        
        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            await DispatchAsync(command);
            
            return NoContent();
        }
    }
}
