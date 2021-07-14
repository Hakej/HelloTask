using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Core.Models;
using HelloTask.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace HelloTask.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        public static readonly IList<Guid> UserIds = new List<Guid>()
        {
            Guid.Parse("7ca0934c-6a99-49a8-9a1f-6b9c737cb44a"),
            Guid.Parse("0e34937b-8f51-4d70-b42c-f0505b766955"),
            Guid.Parse("8df40fa9-8552-4626-9087-f136792351b0")
        };

        public static readonly IList<Guid> AdminIds = new List<Guid>();

        public static readonly IList<Guid> BoardIds = new List<Guid>()
        {
            Guid.Parse("a2156e73-f1df-44ed-bd35-d9bdb5f18962"),
            Guid.Parse("54945914-263c-46df-89cc-f4bc3c375900"),
            Guid.Parse("adce0013-175a-412b-8a6c-8f976cc46ac8")
        };

        public static readonly IList<Guid> TabIds = new List<Guid>()
        {
            Guid.Parse("2317e908-c672-49bd-823b-5518a2b425a6"),
            Guid.Parse("3a42c0a5-01b8-4109-bfb7-7440a7384f05"),
            Guid.Parse("28540832-291b-473a-beac-b7619bd4111b")
        };

        private readonly IUserService _userService;
        private readonly IBoardService _boardService;
        private readonly ITabService _tabService;
        private readonly IAssignmentService _assignmentService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserService userService, ILogger<DataInitializer> logger, IBoardService boardService, ITabService tabService, IAssignmentService assignmentService)
        {
            _userService = userService;
            _logger = logger;
            _boardService = boardService;
            _tabService = tabService;
            _assignmentService = assignmentService;
        }

        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");

            await SeedUsersAsync();
            
            await SeedBoards();
            await SeedTabs();
            await SeedAssignments();

            _logger.LogTrace("Data was initialized.");
        }


        private async Task SeedBoards()
        {
            _logger.LogTrace("Initializing boards...");

            var amountOfSeeds = BoardIds.Count;
            var tasks = new List<Task>();
            for (var i = 1; i <= amountOfSeeds; i++)
            {
                var id = BoardIds[i-1];
                var boardName = $"board{i}";
                tasks.Add(_boardService.PostBoardAsync(id,  UserIds[i-1], boardName));
            }

            await Task.WhenAll(tasks);

            _logger.LogTrace("Boards were initialized.");
        }

        private async Task SeedTabs()
        {
            _logger.LogTrace("Initializing tabs...");

            var amountOfSeeds = Math.Min(BoardIds.Count, TabIds.Count);
            var tasks = new List<Task>();
            for (var i = 1; i <= amountOfSeeds; i++)
            {
                var id = TabIds[i - 1];
                var tabName = $"tab{i}";
                tasks.Add(_tabService.PostTabAsync(id, UserIds[i-1], tabName, BoardIds[i-1]));
            }

            await Task.WhenAll(tasks);

            _logger.LogTrace("Tabs were initialized.");
        }

        private async Task SeedAssignments()
        {
            _logger.LogTrace("Initializing assignments...");

            var amountOfSeeds = TabIds.Count;
            var tasks = new List<Task>();
            for (var i = 1; i <= amountOfSeeds; i++)
            {
                var id = Guid.NewGuid();
                var assignmentName = $"assignment{i}";
                tasks.Add(_assignmentService.PostAssignmentAsync(id, UserIds[i-1], assignmentName, "Test description", TabIds[i - 1]));
            }

            await Task.WhenAll(tasks);

            _logger.LogTrace("Assignments were initialized.");
        }

        public async Task SeedUsersAsync()
        {
            _logger.LogTrace("Initializing Users...");

            var tasks = new List<Task>();
            for (var i = 1; i <= UserIds.Count; i++)
            {
                var id = UserIds[i-1];
                var username = $"user{i}";
                tasks.Add(_userService.RegisterUserAsync(id, $"{username}@test.com", username, "secret", "user"));
            }

            for (var i = 1; i <= AdminIds.Count; i++)
            {
                var id = AdminIds[i-1];
                var username = $"admin{i}";
                tasks.Add(_userService.RegisterUserAsync(id, $"{username}@test.com", username, "secret", "admin"));
            }

            await Task.WhenAll(tasks);

            _logger.LogTrace("Users were initialized.");
        }
    }
}
