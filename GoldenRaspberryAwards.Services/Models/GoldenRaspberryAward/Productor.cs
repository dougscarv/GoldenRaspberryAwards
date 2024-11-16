namespace GoldenRaspberryAwards.Domain.Models.GoldenRaspberryAward
{
    public class Productor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator Productor(Infra.Entities.Productor infraProductor)
        {
            return new Productor
            {
                Id = infraProductor.Id,
                Name = infraProductor.Name,
            };
        }
    }
}
