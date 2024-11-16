using Newtonsoft.Json;

namespace GoldenRaspberryAwards.Domain.Models.ProducersAwards
{
    public class ProducersAwardsIntervalResponse
    {
        [JsonProperty("min")]
        public List<MinIntervalResponse> Min { get; set; }

        [JsonProperty("max")]
        public List<MaxIntervalResponse> Max { get; set; }

        public static explicit operator ProducersAwardsIntervalResponse(ProducersAwardsInterval producersAwardsInterval)
        {
            return new ProducersAwardsIntervalResponse
            {
                Max = producersAwardsInterval.Max.Select(_ => (MaxIntervalResponse)_).ToList(),
                Min = producersAwardsInterval.Min.Select(_ => (MinIntervalResponse)_).ToList()
            };
        }
    }
}
