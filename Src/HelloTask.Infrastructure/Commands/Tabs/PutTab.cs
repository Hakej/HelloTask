using System;

namespace HelloTask.Infrastructure.Commands.Tabs
{
    public class PutTab : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
