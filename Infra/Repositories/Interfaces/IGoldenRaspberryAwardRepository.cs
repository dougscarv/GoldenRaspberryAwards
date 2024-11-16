using GoldenRaspberryAwards.Infra.Entities;

namespace GoldenRaspberryAwards.Infra.Repository.Interfaces
{
    public interface IGoldenRaspberryAwardRepository
    {
        Task<IEnumerable<GoldenRaspberryAward>> GetAllGoldenRaspberryAwardAsync();

        Task SaveGoldenRaspberryAwardAsync(IEnumerable<GoldenRaspberryAward> goldenRaspberryAwards);
    }
}
