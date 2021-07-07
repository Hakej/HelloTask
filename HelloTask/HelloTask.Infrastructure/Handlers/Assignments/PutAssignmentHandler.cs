using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Assignments;

namespace HelloTask.Infrastructure.Handlers.Assignments
{
    public class PutAssignmentHandler : ICommandHandler<PutAssignment>
    {
        public async Task HandleAsync(PutAssignment command)
        {
            await Task.CompletedTask;
        }
    }
}
