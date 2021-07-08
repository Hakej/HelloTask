using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Assignments;
using HelloTask.Infrastructure.Services;

namespace HelloTask.Infrastructure.Handlers.Assignments
{
    public class PostAssignmentHandler : ICommandHandler<PostAssignment>
    {
        private readonly IAssignmentService _assignmentService;

        public PostAssignmentHandler(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        public async Task HandleAsync(PostAssignment command)
        {
            await _assignmentService.PostAssignmentAsync(Guid.NewGuid(), command.Name, command.Description, command.TabId);
        }
    }
}
