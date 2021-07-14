using System;

namespace HelloTask.Infrastructure.Commands.Boards
{
    public class AddBoardCommand : AuthenticatedCommandBase
    {
        public string Name { get; set; }
    }
}
