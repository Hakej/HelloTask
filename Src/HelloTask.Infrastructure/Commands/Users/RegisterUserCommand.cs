namespace HelloTask.Infrastructure.Commands.Users
{
    public class RegisterUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
