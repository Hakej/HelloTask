using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Tabs;
using HelloTask.Infrastructure.Services;
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
            var assignment = await _tabService.GetTabAsync(tabId);

            if (assignment == null)
            {
                return NotFound();
            }

            var foundAssignments = await _tabService.GetAssignmentsFromTabAsync(tabId);

            return Json(foundAssignments);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var assignments = await _tabService.GetAllTabsAsync();

            if (assignments == null)
            {
                return NotFound();
            }

            return Json(assignments);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostTab command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created("tabs", new object());
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutTab command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
