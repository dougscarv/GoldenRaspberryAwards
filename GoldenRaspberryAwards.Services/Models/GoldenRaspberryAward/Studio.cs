namespace GoldenRaspberryAwards.Domain.Models.GoldenRaspberryAward
{
    public class Studio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator Studio(Infra.Entities.Studio infraStudio)
        {
            return new Studio
            {
                Id = infraStudio.Id,
                Name = infraStudio.Name,
            };
        }
    }
}
