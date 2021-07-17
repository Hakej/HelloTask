using System;

namespace HelloTask.Core.Domain
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

        public void SetUsername(string newUsername)
        {
            if (string.IsNullOrEmpty(newUsername))
            {
                throw new DomainException(ErrorCodes.InvalidUsername, "Username can not be empty");
            }
            
            Username = newUsername;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string newEmail)
        {
            if (!IsValidEmail(newEmail))
            {
                throw new DomainException(ErrorCodes.InvalidEmail, "Email is invalid.");
            }
            if (string.IsNullOrEmpty(newEmail))
            {
                throw new DomainException(ErrorCodes.InvalidEmail, "Email can not be empty");
            }
            
            Email = newEmail.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
        
        private bool IsValidEmail(string email)
        {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }
    }
}