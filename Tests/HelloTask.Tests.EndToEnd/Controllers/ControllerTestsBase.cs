using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace HelloTask.Tests.EndToEnd.Controllers
{
    public class ControllerTestsBase : IClassFixture<TestFixture>, IDisposable
    {
        protected readonly TestFixture Fixture;
        protected readonly HttpClient Client;

        protected ControllerTestsBase(TestFixture fixture, ITestOutputHelper output)
        {
            Fixture = fixture;
            fixture.Output = output;
            Client = fixture.CreateClient();
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public void Dispose() => Fixture.Output = null;
    }
}
