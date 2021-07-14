using System;

namespace HelloTask.Infrastructure.Commands.Tabs
{
    public class PostTab : AuthenticatedCommandBase
    {
        public string Name { get; set; }
        public Guid BoardId { get; set; }
    }
}
