using System;
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
        public AssignmentDto Get(Guid id)
            => _assignmentService.GetAssignment(id);
    }
}
