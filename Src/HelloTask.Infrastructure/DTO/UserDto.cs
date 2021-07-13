using System;

namespace HelloTask.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get; protected set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}