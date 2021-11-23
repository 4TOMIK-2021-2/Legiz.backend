using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Legiz.Back_End.LawServiceBC.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;


namespace Legiz.Back_End.Tests.LawServiceBCTests
{
    [Binding]
    public class CustomLegalCaseServiceStepsDefinition
    {
        
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }
        private CustomLegalCaseResource CustomLegalCaseResource { get; set; }

        public CustomLegalCaseServiceStepsDefinition(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/customlegalcases is available")]
        public void GivenTheEndpointHttpsLocalhostApiVCustomLegalCasesIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/customlegalcases");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table saveCustomLegalCaseResource)
        {
            var resource = saveCustomLegalCaseResource.CreateSet<SaveCustomLegalCaseResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode)expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A CustomLegalCase Resource is included in Response Body")]
        public async void ThenACustomLegalCaseResourceIsIncludedInResponseBody(Table expectedCustomLegalCaseResource)
        {
            var expectedResource = expectedCustomLegalCaseResource.CreateSet<CustomLegalCaseResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<CustomLegalCaseResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }
    }
}