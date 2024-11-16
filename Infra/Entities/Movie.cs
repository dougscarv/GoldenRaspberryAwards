namespace GoldenRaspberryAwards.Infra.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Winner { get; set; }
        public Guid GoldenRaspberryAwardId { get; set; }
        public ICollection<Studio> Studios { get; set; }
        public ICollection<Productor> Producers { get; set; }
        public GoldenRaspberryAward GoldenRaspberryAward { get; set; }
    }
}
