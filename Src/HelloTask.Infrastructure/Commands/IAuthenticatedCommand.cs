using System;

namespace HelloTask.Infrastructure.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
