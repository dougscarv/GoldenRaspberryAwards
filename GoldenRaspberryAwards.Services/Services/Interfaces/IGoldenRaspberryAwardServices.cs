using GoldenRaspberryAwards.Domain.Models.ProducersAwards;

namespace GoldenRaspberryAwards.Domain.Services.Interfaces
{
    public interface IGoldenRaspberryAwardServices
    {
        Task<ProducersAwardsInterval> GetAwardsIntervalAsync();
    }
}
