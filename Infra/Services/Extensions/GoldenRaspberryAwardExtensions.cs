using GoldenRaspberryAwards.Infra.Entities;

namespace GoldenRaspberryAwards.Infra.Services.Extensions
{
    public static class GoldenRaspberryAwardExtensions
    {
        public static IEnumerable<GoldenRaspberryAward> ToGoldenRaspberryAward(this IEnumerable<IGrouping<int, GoldenRaspberryAwardsCsv>> goldenRaspberryAwardsCsvsGroup)
        {
            if (goldenRaspberryAwardsCsvsGroup is null) yield break;

            foreach (var goldenRaspberryAwardsCsvGroup in goldenRaspberryAwardsCsvsGroup)
            {
                var goldenRaspberryAwardId = Guid.NewGuid();

                var goldenRaspberryAward = new GoldenRaspberryAward
                {
                    Id = goldenRaspberryAwardId,
                    Year = goldenRaspberryAwardsCsvGroup.Key,
                    Movies = goldenRaspberryAwardsCsvGroup.ToMovies(goldenRaspberryAwardId).ToList(),
                };

                yield return goldenRaspberryAward;
            }
        }
    }
}
