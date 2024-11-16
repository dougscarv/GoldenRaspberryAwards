using GoldenRaspberryAwards.Infra.Entities;

namespace GoldenRaspberryAwards.Infra.Services.Extensions
{
    public static class StringExtensions
    {
        public static bool ToBoolenWinner(this string value)
        {
            if (value.ToLower().Equals("yes"))
            {
                return true;
            }

            return false;
        }

        public static IEnumerable<Studio> ToStudios(this string studios, Guid movieId)
        {
            if (studios is null) yield break;

            foreach (var studio in studios.Replace("and", ",").Split(','))
            {
                yield return new Studio
                {
                    Id = Guid.NewGuid(),
                    MovieId = movieId,
                    Name = studio.Trim()
                };
            }
        }

        public static IEnumerable<Productor> ToProducers(this string producers, Guid movieId)
        {
            if (producers is null) yield break;

            foreach (var productor in producers.Replace("and", ",").Split(','))
            {
                yield return new Productor
                {
                    Id = Guid.NewGuid(),
                    MovieId = movieId,
                    Name = productor.Trim()
                };
            }
        }
    }
}
