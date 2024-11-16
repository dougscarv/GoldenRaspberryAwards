using Newtonsoft.Json;

namespace GoldenRaspberryAwards.Domain.Models.ProducersAwards
{
    public class ProducersAwardsInterval
    {
        [JsonProperty("min")]
        public List<Min> Min { get; set; }

        [JsonProperty("max")]
        public List<Max> Max { get; set; }
    }
}
