using Newtonsoft.Json;

namespace GoldenRaspberryAwards.Domain.Models.ProducersAwards
{
    public class Max
    {
        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("interval")]
        public int Interval { get; set; }

        [JsonProperty("previousWin")]
        public int PreviousWin { get; set; }

        [JsonProperty("followingWin")]
        public int FollowingWin { get; set; }
    }
}
