using System;

namespace HelloTask.Infrastructure.Commands.Boards
{
    public class UpdateBoardCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
