using System;

namespace HelloTask.Core.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Username { get; private set; }
        public string Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

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

        public void ChangeUsername(string newUsername)
        {
            Username = newUsername;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}