using GoldenRaspberryAwards.Domain.Models.ProducersAwards;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;

namespace GoldenRaspberryAwards.Tests
{
    public class ProducersAwardsTests : IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public ProducersAwardsTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;

            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
            _client.BaseAddress = new Uri("https://localhost:7037");
        }

        [Fact]
        public async Task GetAwardsProducersInterval_Min()
        {
            // Act
            var response = await _client.GetAsync("/api/producers/awards/interval");
            var content = await response.Content.ReadAsStringAsync();
            
            var producersAwardsIntervalResponse = JsonSerializer.Deserialize<ProducersAwardsIntervalResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(producersAwardsIntervalResponse);
            Assert.NotNull(producersAwardsIntervalResponse.Min);
            Assert.True(producersAwardsIntervalResponse.Min.Count > 0);

            var minInterval = producersAwardsIntervalResponse.Min.First();
            
            Assert.Equal("Joel Silver", minInterval.Producer);
            Assert.Equal(1, minInterval.Interval);
            Assert.Equal(1990, minInterval.PreviousWin);
            Assert.Equal(1991, minInterval.FollowingWin);
        }

        [Fact]
        public async Task GetAwardsProducersInterval_Max()
        {
            // Act
            var response = await _client.GetAsync("/api/producers/awards/interval");
            var content = await response.Content.ReadAsStringAsync();

            var producersAwardsIntervalResponse = JsonSerializer.Deserialize<ProducersAwardsIntervalResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(producersAwardsIntervalResponse);
            Assert.NotNull(producersAwardsIntervalResponse.Max);
            Assert.True(producersAwardsIntervalResponse.Max.Count > 0);

            var maxInterval = producersAwardsIntervalResponse.Max.First();
            
            Assert.Equal("Matthew Vaughn", maxInterval.Producer);
            Assert.Equal(13, maxInterval.Interval);
            Assert.Equal(2002, maxInterval.PreviousWin);
            Assert.Equal(2015, maxInterval.FollowingWin);
        }
    }
}