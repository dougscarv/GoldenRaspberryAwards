namespace GoldenRaspberryAwards.Domain.Models.GoldenRaspberryAward
{
    public class GoldenRaspberryAward
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public List<Movie> Movies { get; set; }

        public static explicit operator GoldenRaspberryAward(Infra.Entities.GoldenRaspberryAward infraAward)
        {
            return new GoldenRaspberryAward
            {
                Id = infraAward.Id,
                Year = infraAward.Year,
                Movies = infraAward.Movies.Select(_ => (Movie)_).ToList()
            };
        }
    }
}
