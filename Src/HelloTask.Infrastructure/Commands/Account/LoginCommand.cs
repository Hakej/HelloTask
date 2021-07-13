using System;

namespace HelloTask.Infrastructure.Commands.Account
{
    public class  LoginCommand : ICommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
