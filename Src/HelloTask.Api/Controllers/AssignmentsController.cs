using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Assignments;
using HelloTask.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloTask.Api.Controllers
{
    public class AssignmentsController : ApiControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService, 
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var assignment = await _assignmentService.GetAssignmentAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Json(assignment);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var assignments = await _assignmentService.GetAllAssignmentsAsync();

            return Json(assignments);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAssignment command)
        {
            await DispatchAsync(command);

            return Created("assignments/", new object());
        }
    }
}
