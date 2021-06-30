using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HelloTask.Infrastructure.Commands.Assignments;
using HelloTask.Infrastructure.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace HelloTask.Tests.EndToEnd.Controllers
{
    public class AssignmentsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public AssignmentsControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task get_assigments_should_have_assignments()
        {
            var assignments = await GetAllAssignmentsAsync();

            assignments.Should().NotBeEmpty();
        }

        [Fact]
        public async Task assignment_should_be_created()
        {
            const string newAssignmentName = "Mock task";
            const string newAssignmentDescription = "Mock description";

            var request = new PostAssignment()
            {
                Name = newAssignmentName,
                Description = newAssignmentDescription
            };

            var payload = GetPayload(request);
            var response = await _client.PostAsync("assignments", payload);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().Should().BeEquivalentTo("assignments/");

            var assignments = await GetAllAssignmentsAsync();
            assignments.Should().Contain(x => x.Name == newAssignmentName && x.Description == newAssignmentDescription);

            var foundAssignment = assignments.SingleOrDefault(x => x.Name == newAssignmentName);
            var assignment = await _client.GetAsync($"assignments/{foundAssignment.Id}");
            assignment.Should().NotBeNull();
        }

        private async Task<IEnumerable<AssignmentDto>> GetAllAssignmentsAsync()
        {
            var response = await _client.GetAsync("assignments/");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<AssignmentDto>>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
