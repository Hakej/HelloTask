using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands.Assignments;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<AssignmentDto> Get(Guid id)
            => await _assignmentService.GetAssignmentAsync(id);

        [HttpPost]
        public async Task Post([FromBody]PostAssignment command) 
            => await _assignmentService.PostAssignmentAsync(command.Name, command.Description);
        }
}
