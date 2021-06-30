using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands.Assignments;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace HelloTask.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentsController(IAssignmentService assignmentService)
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

            if (assignments == null)
            {
                return NotFound();
            }

            return Json(assignments);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAssignment command)
        {
            await _assignmentService.PostAssignmentAsync(command.Name, command.Description);

            return Created("assignments/", new object());
        }
    }
}
