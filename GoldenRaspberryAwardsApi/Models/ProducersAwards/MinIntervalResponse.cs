using Newtonsoft.Json;

namespace GoldenRaspberryAwards.Domain.Models.ProducersAwards
{
    public class MinIntervalResponse
    {
        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("interval")]
        public int Interval { get; set; }

        [JsonProperty("previousWin")]
        public int PreviousWin { get; set; }

        [JsonProperty("followingWin")]
        public int FollowingWin { get; set; }

        public static explicit operator MinIntervalResponse(Min min)
        {
            return new MinIntervalResponse
            {
                Producer = min.Producer,
                Interval = min.Interval,
                PreviousWin = min.PreviousWin,
                FollowingWin = min.FollowingWin
            };
        }
    }
}
