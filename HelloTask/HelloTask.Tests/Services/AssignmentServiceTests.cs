using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
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
        public async Task post_assignment_async_should_invoke_add_async_on_repository()
        {
            var assignmentRepository = new Mock<IAssignmentRepository>();
            var mapperMock = new Mock<IMapper>();

            var assignmentService = new AssignmentService(assignmentRepository.Object, mapperMock.Object);

            await assignmentService.PostAssignmentAsync("Mock task", "Mock description");

            assignmentRepository.Verify(x => x.AddAsync(It.IsAny<Assignment>()), Times.Once);
        }
    }
}
