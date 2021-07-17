using System;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Domain;
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
            var assignmentRepositoryMock = new Mock<IAssignmentRepository>();
            var tabRepositoryMock = new Mock<ITabRepository>();
            var mapperMock = new Mock<IMapper>();
            var userRepositoryMock = new Mock<IUserRepository>();

            var owner = new User(Guid.NewGuid(), "", "", "", "", "");
            userRepositoryMock.Setup(s => s.GetAsync(owner.Id))
                              .Returns(Task.FromResult(owner));

            var board = new Board(Guid.NewGuid(), owner, "Mock board");
            var tab = new Tab(new Guid(), owner, "Mock tab", board);
            tabRepositoryMock.Setup(s => s.GetAsync(tab.Id))
                         .Returns(Task.FromResult(tab));

            var assignmentService = new AssignmentService(mapperMock.Object, assignmentRepositoryMock.Object, tabRepositoryMock.Object, userRepositoryMock.Object);
            await assignmentService.PostAssignmentAsync(Guid.NewGuid(), owner.Id, "Mock task", "Mock description", tab.Id);

            assignmentRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Assignment>()), Times.Once);
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
