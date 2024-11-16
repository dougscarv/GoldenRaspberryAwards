using Newtonsoft.Json;

namespace GoldenRaspberryAwards.Domain.Models.ProducersAwards
{
    public class MaxIntervalResponse
    {
        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("interval")]
        public int Interval { get; set; }

        [JsonProperty("previousWin")]
        public int PreviousWin { get; set; }

        [JsonProperty("followingWin")]
        public int FollowingWin { get; set; }

        public static explicit operator MaxIntervalResponse(Max MaxDomain)
        {
            return new MaxIntervalResponse
            {
                Producer = MaxDomain.Producer,
                Interval = MaxDomain.Interval,
                PreviousWin = MaxDomain.PreviousWin,
                FollowingWin = MaxDomain.FollowingWin
            };
        }
    }
}
