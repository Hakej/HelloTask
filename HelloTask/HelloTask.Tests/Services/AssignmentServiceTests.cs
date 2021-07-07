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
        public async Task post_assignment_async_with_valid_tabid_should_invoke_add_async_on_repository()
        {
            var assignmentRepository = new Mock<IAssignmentRepository>();
            var tabRepository = new Mock<ITabRepository>();
            var mapperMock = new Mock<IMapper>();

            var tabId = Guid.NewGuid();

            tabRepository.Setup(s => s.GetAsync(tabId))
                .Returns(Task.FromResult(new Tab(tabId, "Mock tab")));

            var assignmentService = new AssignmentService(mapperMock.Object, assignmentRepository.Object, tabRepository.Object);
            await assignmentService.PostAssignmentAsync(Guid.NewGuid(), "Mock task", "Mock description", tabId);

            assignmentRepository.Verify(x => x.AddAsync(It.IsAny<Assignment>()), Times.Once);
        }

        [Fact]
        public async Task post_assignment_async_with_invalid_tabid_should_throw_exception()
        {
            var assignmentRepository = new Mock<IAssignmentRepository>();
            var tabRepository = new Mock<ITabRepository>();
            var mapperMock = new Mock<IMapper>();

            var assignmentService = new AssignmentService(mapperMock.Object, assignmentRepository.Object, tabRepository.Object);

            await Assert.ThrowsAsync<Exception>(() =>
                assignmentService.PostAssignmentAsync(Guid.NewGuid(), "Mock task", "Mock description", Guid.Empty));
        }
    }
}
