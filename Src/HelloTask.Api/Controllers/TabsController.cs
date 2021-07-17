using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Tabs;
using HelloTask.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloTask.Api.Controllers
{
    public class TabsController : ApiControllerBase
    {
        private readonly ITabService _tabService;

        public TabsController(ITabService tabService,
        ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _tabService = tabService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var assignment = await _tabService.GetTabAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Json(assignment);
        }

        [HttpGet("Assignments/{tabId}")]
        public async Task<IActionResult> GetAssignments(Guid tabId)
        {
            var tab = await _tabService.GetTabAsync(tabId);

            if (tab == null)
            {
                return NotFound();
            }

            var foundAssignments = await _tabService.GetAssignmentsFromTabAsync(tabId);

            return Json(foundAssignments);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tabs = await _tabService.GetAllTabsAsync();
            return Json(tabs);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostTab command)
        {
            await DispatchAsync(command);

            return Created("tabs", new object());
        }
    }
}
