using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HelloTask.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");

            var tasks = new List<Task>();
            for (var i = 1; i <= 10; i++)
            {
                var id = Guid.NewGuid();
                var username = $"user{i}";
                tasks.Add(_userService.RegisterUserAsync(id, $"{username}@test.com", username, "secret", "user"));
                _logger.LogTrace($"Created a new user: '{username}'");
            }

            for (var i = 1; i <= 3; i++)
            {
                var id = Guid.NewGuid();
                var username = $"admin{i}";
                _logger.LogTrace($"Created a new admin: '{username}'");
                tasks.Add(_userService.RegisterUserAsync(id, $"{username}@test.com", username, "secret", "admin"));
            }

            await Task.WhenAll(tasks);

            _logger.LogTrace("Data was initialized.");
        }
    }
}
