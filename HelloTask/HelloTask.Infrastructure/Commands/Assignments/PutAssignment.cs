using System;

namespace HelloTask.Infrastructure.Commands.Assignments
{
    public class PutAssignment : ICommand
    {
        public Guid Id { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }

        public Guid TabId { get; set; }
    }
}
