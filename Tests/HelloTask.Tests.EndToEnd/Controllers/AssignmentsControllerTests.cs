﻿using System.Collections.Generic;
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
        public async Task Assignment_WithMissingTabId_ReturnsInternalServerError()
        {
            var command = new PostAssignment()
            {
                Name = "Mock task",
                Description = "Mock description"
            };

            var payload = GetPayload(command);
            var response = await Client.PostAsync("assignments", payload);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Update_WithCorrectAssignment_ReturnsNoContent()
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
