using System;

namespace HelloTask.Core.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
                
        }

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
