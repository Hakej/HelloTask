using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTask.Core.Domain;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Mappers;
using HelloTask.Infrastructure.Services;
using Moq;
using Xunit;

namespace HelloTask.Tests.Services
{
    public class TabServiceTests
    {
        [Fact]
        public async Task Get_AssignmentsFromTabAsync_ReturnsAssignmentsOnlyFromThisTab()
        {
            var assignmentRepository = new Mock<IAssignmentRepository>();
            var tabRepository = new Mock<ITabRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var boardRepositoryMock = new Mock<IBoardRepository>();

            var mapper = AutoMapperConfig.Initialize();

            var owner = new User(Guid.NewGuid(), "", "", "", "", "");
            var board = new Board(Guid.NewGuid(), owner, "Mock board");
            
            var ourTab = new Tab(Guid.NewGuid(), owner, "", board);
            var otherTabId = new Tab(Guid.NewGuid(), owner, "", board);

            var ourAssignment = new Assignment(Guid.NewGuid(), owner, "Our assignment", "Our description", ourTab);
            var otherAssignment = new Assignment(Guid.NewGuid(), owner, "Other assignment", "Other description", otherTabId);

            assignmentRepository.Setup(s => s.GetAllAsync())
                                .Returns(
                                    Task.FromResult(new List<Assignment>()
                                    {
                                        ourAssignment,
                                        otherAssignment
                                    } as IEnumerable<Assignment>));
            
            var tabService = new TabService(mapper, tabRepository.Object, assignmentRepository.Object, userRepositoryMock.Object, boardRepositoryMock.Object);
            var result = await tabService.GetAssignmentsFromTabAsync(ourTab.Id);

            var assignmentDtos = result as AssignmentDto[] ?? result.ToArray();
            Assert.Contains(assignmentDtos, item => item.Id == ourAssignment.Id);
            Assert.DoesNotContain(assignmentDtos, item => item.Id == otherAssignment.Id);
        }
    }
}