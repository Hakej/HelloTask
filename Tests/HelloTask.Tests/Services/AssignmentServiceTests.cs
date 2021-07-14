using System;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.Services;
using Moq;
using Xunit;

namespace HelloTask.Tests.Services
{
    public class AssignmentServiceTests
    {
        [Fact]
        public async Task PostAssignmentAsync_WithValidTabId_InvokesAddAsyncOnRepositoryOnce()
        {
            var assignmentRepository = new Mock<IAssignmentRepository>();
            var tabRepository = new Mock<ITabRepository>();
            var mapperMock = new Mock<IMapper>();
            var userRepositoryMock = new Mock<IUserRepository>();

            var tabId = Guid.NewGuid();
            tabRepository.Setup(s => s.GetAsync(tabId))
                .Returns(Task.FromResult(new Tab(tabId, "Mock tab", Guid.NewGuid())));

            var userId = Guid.NewGuid();
            userRepositoryMock.Setup(s => s.GetAsync(userId))
                .Returns(Task.FromResult(new User(userId, "", "", "", "", "")));

            var assignmentService = new AssignmentService(mapperMock.Object, assignmentRepository.Object, tabRepository.Object, userRepositoryMock.Object);
            await assignmentService.PostAssignmentAsync(Guid.NewGuid(), userId, "Mock task", "Mock description", tabId);

            assignmentRepository.Verify(x => x.AddAsync(It.IsAny<Assignment>()), Times.Once);
        }

        [Fact]
        public async Task PostAssignmentAsync_WithInvalidTabId_ThrowsArgumentException()
        {
            var assignmentRepository = new Mock<IAssignmentRepository>();
            var tabRepository = new Mock<ITabRepository>();
            var mapperMock = new Mock<IMapper>();
            var userRepositoryMock = new Mock<IUserRepository>();

            var assignmentService = new AssignmentService(mapperMock.Object, assignmentRepository.Object, tabRepository.Object, userRepositoryMock.Object);

            await Assert.ThrowsAsync<ArgumentException>(() =>
                assignmentService.PostAssignmentAsync(Guid.NewGuid(), DataInitializer.UserIds[0],  "Mock task", "Mock description", Guid.Empty));
        }
    }
}
