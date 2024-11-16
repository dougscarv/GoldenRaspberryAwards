namespace GoldenRaspberryAwards.Infra.Entities
{
    public class GoldenRaspberryAward
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
