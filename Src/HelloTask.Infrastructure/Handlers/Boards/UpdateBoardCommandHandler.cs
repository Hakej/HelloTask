using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Boards;

namespace HelloTask.Infrastructure.Handlers.Boards
{
    public class UpdateBoardCommandHandler : ICommandHandler<UpdateBoardCommand>
    {
        public async Task HandleAsync(UpdateBoardCommand command)
        {
            await Task.CompletedTask;
        }
    }
}
