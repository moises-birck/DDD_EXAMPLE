using Entities.Entities.RequestObject;
using Entities.Entities.ResponseObjects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestApps
{
    public class CalculateValuesTest
    {
        private readonly TestServer _server1;
        private readonly HttpClient _client1;

        public CalculateValuesTest()
        {
            // Arrange
            _server1 = new TestServer(new WebHostBuilder()
               .UseStartup<API_EXAMPLE.Startup>());
            _client1 = _server1.CreateClient();
        }


        [Fact]
        public async Task CalculateValuesTest1()
        {
            // Act
            SeeValuesRequest see = new SeeValuesRequest();
            SeeValuesResponse seeResp = new SeeValuesResponse();
            
            see.Origin = 11;
            see.Destiny = 16;
            see.Plan = "FaleMais 30";
            see.CallMinutes = 20;

            seeResp.request = see;
            seeResp.WithPlan = (0).ToString("C");
            seeResp.NoPlan = (38.00).ToString("C");

            var jsonContent = JsonConvert.SerializeObject(see);
            var expectedResponse = JsonConvert.SerializeObject(seeResp);

            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client1.PostAsync("/SeeValues", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResponse.ToLower(), responseString.ToLower());
        }

        [Fact]
        public async Task CalculateValuesTest2()
        {
            // Act
            SeeValuesRequest see = new SeeValuesRequest();
            SeeValuesResponse seeResp = new SeeValuesResponse();

            see.Origin = 11;
            see.Destiny = 17;
            see.Plan = "FaleMais 60";
            see.CallMinutes = 80;

            seeResp.request = see;
            seeResp.WithPlan = (37.40).ToString("C");
            seeResp.NoPlan = (136.00).ToString("C");

            var jsonContent = JsonConvert.SerializeObject(see);
            var expectedResponse = JsonConvert.SerializeObject(seeResp);

            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client1.PostAsync("/SeeValues", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResponse.ToLower(), responseString.ToLower());
        }
        [Fact]
        public async Task CalculateValuesTest3()
        {
            // Act
            SeeValuesRequest see = new SeeValuesRequest();
            SeeValuesResponse seeResp = new SeeValuesResponse();

            see.Origin = 18;
            see.Destiny = 11;
            see.Plan = "FaleMais 120";
            see.CallMinutes = 200;

            seeResp.request = see;
            seeResp.WithPlan = (167.20).ToString("C");
            seeResp.NoPlan = (380.00).ToString("C");

            var jsonContent = JsonConvert.SerializeObject(see);
            var expectedResponse = JsonConvert.SerializeObject(seeResp);

            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client1.PostAsync("/SeeValues", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResponse.ToLower(), responseString.ToLower());
        }

        [Fact]
        public async Task CalculateValuesTest4()
        {
            // Act
            SeeValuesRequest see = new SeeValuesRequest();
            SeeValuesResponse seeResp = new SeeValuesResponse();

            see.Origin = 18;
            see.Destiny = 17;
            see.Plan = "FaleMais 60";
            see.CallMinutes = 100;

            seeResp.request = see;
            seeResp.WithPlan = "-";
            seeResp.NoPlan = "-";

            var jsonContent = JsonConvert.SerializeObject(see);
            var expectedResponse = JsonConvert.SerializeObject(seeResp);

            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client1.PostAsync("/SeeValues", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(expectedResponse.ToLower(), responseString.ToLower());
        }
    }
}