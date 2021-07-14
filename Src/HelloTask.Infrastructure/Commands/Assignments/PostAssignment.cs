using System;

namespace HelloTask.Infrastructure.Commands.Assignments
{
    public class PostAssignment : AuthenticatedCommandBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid TabId { get; set; }
    }
}
