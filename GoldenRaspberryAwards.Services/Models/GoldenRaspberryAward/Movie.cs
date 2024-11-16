namespace GoldenRaspberryAwards.Domain.Models.GoldenRaspberryAward
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Winner { get; set; }
        public List<Studio> Studios { get; set; }
        public List<Productor> Producers { get; set; }


        public static explicit operator Movie(Infra.Entities.Movie infraMovie)
        {
            return new Movie
            {
                Id = infraMovie.Id,
                Title = infraMovie.Title,
                Winner = infraMovie.Winner,
                Studios = infraMovie.Studios.Select(_ => (Studio)_).ToList(),
                Producers = infraMovie.Producers.Select(_ => (Productor)_).ToList()
            };
        }
    }
}
