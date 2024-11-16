using GoldenRaspberryAwards.Domain.Models.GoldenRaspberryAward;
using GoldenRaspberryAwards.Domain.Models.ProducersAwards;

namespace GoldenRaspberryAwards.Domain.Services.Extensions
{
    public static class GoldenRaspberryAwardExtensions
    {

        public static ProducersAwardsInterval ToProducersAwardsInterval(this IEnumerable<GoldenRaspberryAward> goldenRaspberryAwards)
        {
            if (goldenRaspberryAwards is null || !goldenRaspberryAwards.Any()) return new ProducersAwardsInterval();

            var producersWithMultipleWins = goldenRaspberryAwards
                .GetAwardsWinnersMovies()
                .GetAwardsWithProducersWithMultipleWins().ToList();

            var producerWins = producersWithMultipleWins
                .SelectMany(award => award.Movies
                .SelectMany(movie => movie.Producers
                .Select(producer => new
                {
                    Producer = producer.Name,
                    award.Year
                })))
                .GroupBy(_ => _.Producer)
                .Select(_ =>
                {
                    var orderedWins = _.OrderBy(x => x.Year).ToList();

                    // Encontrando o menor intervalo
                    var minInterval = int.MaxValue;
                    Min minEntry = new();

                    for (int i = 1; i < orderedWins.Count; i++)
                    {
                        int interval = orderedWins[i].Year - orderedWins[i - 1].Year;
                        if (interval < minInterval)
                        {
                            minInterval = interval;
                            minEntry = new Min
                            {
                                Producer = _.Key,
                                Interval = interval,
                                PreviousWin = orderedWins[i - 1].Year,
                                FollowingWin = orderedWins[i].Year
                            };
                        }
                    }

                    // Encontrando o maior intervalo
                    var maxInterval = int.MinValue;
                    Max maxEntry = new();

                    for (int i = 1; i < orderedWins.Count; i++)
                    {
                        int interval = orderedWins[i].Year - orderedWins[i - 1].Year;
                        if (interval > maxInterval)
                        {
                            maxInterval = interval;
                            maxEntry = new Max
                            {
                                Producer = _.Key,
                                Interval = interval,
                                PreviousWin = orderedWins[i - 1].Year,
                                FollowingWin = orderedWins[i].Year
                            };
                        }
                    }
                    return new { MinEntry = minEntry, MaxEntry = maxEntry };
                })
                .ToList();


            var minInterval = producerWins.Select(x => x.MinEntry).OrderBy(x => x.Interval).FirstOrDefault()?.Interval;
            var maxInterval = producerWins.Select(x => x.MaxEntry).OrderByDescending(x => x.Interval).FirstOrDefault()?.Interval;

            var producersAwardsInterval = new ProducersAwardsInterval
            {
                Min = producerWins.Select(x => x.MinEntry).Where(_ => _.Interval.Equals(minInterval)).ToList(),
                Max = producerWins.Select(x => x.MaxEntry).Where(_ => _.Interval.Equals(maxInterval)).ToList()
            };

            return producersAwardsInterval;
        }

        public static IEnumerable<GoldenRaspberryAward> GetAwardsWinnersMovies(this IEnumerable<GoldenRaspberryAward> goldenRaspberryAwards)
        {
            if (goldenRaspberryAwards is null || !goldenRaspberryAwards.Any()) yield break;

            foreach (var goldenRaspberryAwardItem in goldenRaspberryAwards)
            {
                foreach (var winningMovies in goldenRaspberryAwardItem.Movies.Where(_ => _.Winner))
                {
                    yield return new GoldenRaspberryAward
                    {
                        Id = goldenRaspberryAwardItem.Id,
                        Year = goldenRaspberryAwardItem.Year,
                        Movies = [winningMovies]
                    };
                }
            }
        }

        public static IEnumerable<GoldenRaspberryAward> GetAwardsWithProducersWithMultipleWins(this IEnumerable<GoldenRaspberryAward> goldenRaspberryAwards)
        {
            if (goldenRaspberryAwards == null) yield break;

            var producerWins = new Dictionary<string, int>();
            CountProductorsVictories(goldenRaspberryAwards, producerWins);

            var producersWithMultipleWins = producerWins
                .Where(_ => _.Value >= 2)
                .Select(_ => _.Key)
                .ToHashSet();

            foreach (var award in goldenRaspberryAwards)
            {
                if (award.Movies.Any(movie => movie.Winner && movie.Producers.Any(producer => producersWithMultipleWins.Contains(producer.Name))))
                {
                    var firstMovie = award.Movies.FirstOrDefault();

                    if (firstMovie != null && firstMovie.Producers.Count > 1)
                    {
                        var producersToRemove = firstMovie.Producers
                            .Where(producer => !producersWithMultipleWins.Contains(producer.Name))
                            .ToList();

                        foreach (var producer in producersToRemove)
                        {
                            firstMovie.Producers.Remove(producer);
                        }
                    }
                    yield return award;
                }
            }
        }

        private static void CountProductorsVictories(IEnumerable<GoldenRaspberryAward> goldenRaspberryAwards, Dictionary<string, int> producerWins)
        {
            foreach (var award in goldenRaspberryAwards)
            {
                foreach (var movie in award.Movies.Where(m => m.Winner))
                {
                    foreach (var producer in movie.Producers)
                    {
                        if (producerWins.ContainsKey(producer.Name))
                            producerWins[producer.Name]++;
                        else
                            producerWins[producer.Name] = 1;
                    }
                }
            }
        }




        public static IEnumerable<Max> ToMaxProductorInterval(this IEnumerable<GoldenRaspberryAward> goldenRaspberryAwards)
        {
            if (goldenRaspberryAwards is null || !goldenRaspberryAwards.Any()) yield break;


        }

        public static IEnumerable<Min> ToMinProductorInterval(this IEnumerable<GoldenRaspberryAward> goldenRaspberryAwards)
        {
            if (goldenRaspberryAwards is null || !goldenRaspberryAwards.Any()) yield break;


        }
    }
}
