namespace GoldenRaspberryAwards.Infra.Entities
{
    public class Studio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
