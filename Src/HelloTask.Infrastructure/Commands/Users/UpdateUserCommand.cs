namespace HelloTask.Infrastructure.Commands.Users
{
    public class UpdateUserCommand : AuthenticatedCommandBase
    {
        public string NewUsername { get; set; }
    }
}