using System;

namespace HelloTask.Core.Models
{
    public class User
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }
        public string Salt { get; protected set; }
        public string Username { get; }
        public string Role { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        public User(Guid userId, string email, string username, string role,
            string password, string salt)
        {
            Id = userId;
            Email = email.ToLowerInvariant();
            Username = username;
            Role = role;
            Password = password;
            Role = role;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
