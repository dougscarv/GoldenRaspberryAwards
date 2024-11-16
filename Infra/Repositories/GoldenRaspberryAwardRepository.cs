using GoldenRaspberryAwards.Infra.Context;
using GoldenRaspberryAwards.Infra.Entities;
using GoldenRaspberryAwards.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GoldenRaspberryAwards.Infra.Repository
{
    public class GoldenRaspberryAwardRepository : IGoldenRaspberryAwardRepository
    {
        private readonly GoldenRaspberryAwardsContext _goldenRaspberryAwardsContext;

        public GoldenRaspberryAwardRepository(GoldenRaspberryAwardsContext goldenRaspberryAwardsContext)
        {
            _goldenRaspberryAwardsContext = goldenRaspberryAwardsContext;
        }

        public async Task<IEnumerable<GoldenRaspberryAward>> GetAllGoldenRaspberryAwardAsync() 
        {
            var awards = await _goldenRaspberryAwardsContext.GoldenRaspberryAward
                .Include(_ => _.Movies).ThenInclude(_ => _.Studios)
                .Include(_ => _.Movies).ThenInclude(_ => _.Producers).ToListAsync();

            return awards;
        }

        public async Task SaveGoldenRaspberryAwardAsync(IEnumerable<GoldenRaspberryAward> goldenRaspberryAwards)
        {
            await _goldenRaspberryAwardsContext.GoldenRaspberryAward.AddRangeAsync(goldenRaspberryAwards);
            await _goldenRaspberryAwardsContext.SaveChangesAsync();
        }
    }
}
