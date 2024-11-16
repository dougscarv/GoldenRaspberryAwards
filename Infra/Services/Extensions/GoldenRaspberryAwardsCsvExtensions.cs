using GoldenRaspberryAwards.Infra.Entities;

namespace GoldenRaspberryAwards.Infra.Services.Extensions
{
    public static class GoldenRaspberryAwardsCsvExtensions
    {
        public static IEnumerable<Movie> ToMovies(this IEnumerable<GoldenRaspberryAwardsCsv> goldenRaspberryAwards, Guid goldenRaspberryAwardId)
        {
            if (goldenRaspberryAwards is null) yield break;

            foreach (var goldenRaspberryAward in goldenRaspberryAwards)
            {
                var movieId = Guid.NewGuid();
                yield return new Movie
                {
                    Id = movieId,
                    Winner = goldenRaspberryAward.Winner.ToLower().Trim().Equals("yes"),
                    Studios = goldenRaspberryAward.Studios.ToStudios(movieId).ToList(),
                    Producers = goldenRaspberryAward.Producers.ToProducers(movieId).ToList(),
                    GoldenRaspberryAwardId = goldenRaspberryAwardId,
                    Title = goldenRaspberryAward.Title.Trim()
                };
            }
        }
    }
}
