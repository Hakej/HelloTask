using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using HelloTask.Infrastructure.Commands.Assignments;
using HelloTask.Infrastructure.DTO;
using Newtonsoft.Json;
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
        public async Task get_assigments_should_have_assignments()
        {
            var assignments = await GetAllAssignmentsAsync();

            assignments.Should().NotBeEmpty();

            foreach (var assignment in assignments)
            {
                Fixture.Output.WriteLine($"Name: {assignment.Name}, Description: {assignment.Description}");
            }
        }

        [Fact]
        public async Task assignment_should_be_created()
        {
            const string newAssignmentName = "Mock task";
            const string newAssignmentDescription = "Mock description";

            var command = new PostAssignment()
            {
                Name = newAssignmentName,
                Description = newAssignmentDescription
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync("assignments", payload);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo("assignments/");

            var assignments = await GetAllAssignmentsAsync();
            assignments.Should().Contain(x => x.Name == newAssignmentName && x.Description == newAssignmentDescription);

            var foundAssignment = assignments.SingleOrDefault(x => x.Name == newAssignmentName);
            var assignment = await Client.GetAsync($"assignments/{foundAssignment.Id}");
            assignment.Should().NotBeNull();
        }

        [Fact]
        public async Task given_new_name_and_description_assignment_should_be_changed()
        {
            var command = new PutAssignment()
            {
                NewName = "New name",
                NewDescription = "New description"
            };

            var payload = GetPayload(command);
            var response = await Client.PutAsync("assignments", payload);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }

        private async Task<IEnumerable<AssignmentDto>> GetAllAssignmentsAsync()
        {
            var response = await Client.GetAsync("assignments/");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<AssignmentDto>>(responseString);
        }
    }
}
