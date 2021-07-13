using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.Mappers;
using HelloTask.Infrastructure.Services;
using Moq;
using Xunit;

namespace HelloTask.Tests.Services
{
    public class TabServiceTests
    {
        [Fact]
        public async Task get_assignments_from_tab_async_should_return_the_assignments_only_from_this_tab()
        {
            var assignmentRepository = new Mock<IAssignmentRepository>();
            var tabRepository = new Mock<ITabRepository>();

            var mapper = AutoMapperConfig.Initialize();

            var ourTabId = DataInitializer.TabIds[0];
            var otherTabId = DataInitializer.TabIds[1];
            
            var ourAssignment = new Assignment(Guid.NewGuid(), "Our assignment", "Our description", ourTabId);
            var otherAssignment = new Assignment(Guid.NewGuid(), "Other assignment", "Other description", otherTabId);

            assignmentRepository.Setup(s => s.GetAllAsync())
                                .Returns(
                                    Task.FromResult(new List<Assignment>()
                                    {
                                        ourAssignment,
                                        otherAssignment
                                    } as IEnumerable<Assignment>));
            
            var tabService = new TabService(mapper, tabRepository.Object, assignmentRepository.Object);
            var result = await tabService.GetAssignmentsFromTabAsync(ourTabId);
                
            Assert.Contains(result, item => item.Id == ourAssignment.Id);
            Assert.DoesNotContain(result, item => item.Id == otherAssignment.Id);
        }
    }
}