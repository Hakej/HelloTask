using HelloTask.Infrastructure.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloTask.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher)
            : base(commandDispatcher)
        {
        }
        
        [HttpGet]
        [Authorize(policy: "admin")]
        [Route("auth")]
        public IActionResult GetAuth()
        {
            return Content("Auth");
        }
    }
}
