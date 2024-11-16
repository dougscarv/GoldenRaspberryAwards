using GoldenRaspberryAwards.Domain.Models.GoldenRaspberryAward;
using GoldenRaspberryAwards.Domain.Models.ProducersAwards;
using GoldenRaspberryAwards.Domain.Services.Extensions;
using GoldenRaspberryAwards.Domain.Services.Interfaces;
using GoldenRaspberryAwards.Infra.Repository.Interfaces;

namespace GoldenRaspberryAwards.Domain.Services
{
    public class GoldenRaspberryAwardServices : IGoldenRaspberryAwardServices
    {
        private readonly IGoldenRaspberryAwardRepository _goldenRaspberryAwardRepository;

        public GoldenRaspberryAwardServices(IGoldenRaspberryAwardRepository goldenRaspberryAwardRepository)
        {
            _goldenRaspberryAwardRepository = goldenRaspberryAwardRepository;
        }

        public async Task<ProducersAwardsInterval> GetAwardsIntervalAsync()
        {
            var goldenRaspberryAwardList = await _goldenRaspberryAwardRepository.GetAllGoldenRaspberryAwardAsync();

            return goldenRaspberryAwardList.Select(_ => (GoldenRaspberryAward)_).ToProducersAwardsInterval();
        }
    }
}
