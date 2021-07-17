using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using HelloTask.Infrastructure.Commands.Assignments;
using Xunit;
using Xunit.Abstractions;

namespace HelloTask.Tests.EndToEnd.Controllers
{
    public class AssignmentsControllerTests : ControllerTestsBase
    {
        public AssignmentsControllerTests(TestFixture fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        public async Task PostingAssignment_WithoutAuthorization_ReturnsUnauthorizedError()
        {
            var command = new PostAssignment()
            {
                Name = "Mock task",
                Description = "Mock description"
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync("assignments", payload);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Unauthorized);
        }
    }
}
