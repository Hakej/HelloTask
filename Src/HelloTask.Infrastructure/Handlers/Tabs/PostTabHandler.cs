using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Tabs;
using HelloTask.Infrastructure.Services;

namespace HelloTask.Infrastructure.Handlers.Tabs
{
    public class PostTabHandler : ICommandHandler<PostTab>
    {
        private readonly ITabService _tabService;

        public PostTabHandler(ITabService tabService)
        {
            _tabService = tabService;
        }

        public async Task HandleAsync(PostTab command)
        {
            await _tabService.PostTabAsync(Guid.NewGuid(), command.Name);
        }
    }
}
