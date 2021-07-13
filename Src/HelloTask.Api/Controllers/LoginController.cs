using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Account;
using HelloTask.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HelloTask.Api.Controllers
{
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public LoginController(ICommandDispatcher commandDispatcher,
            IMemoryCache cache) : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginCommand command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}
