using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Tabs;

namespace HelloTask.Infrastructure.Handlers.Tabs
{
    public class PutTabHandler : ICommandHandler<PutTab>
    {
        public async Task HandleAsync(PutTab command)
        {
            await Task.CompletedTask;
        }
    }
}
