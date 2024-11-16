using GoldenRaspberryAwards.Domain.Services.Interfaces;
using GoldenRaspberryAwards.Infra.Services.Interfaces;

namespace GoldenRaspberryAwards.Domain.Services
{
    public class CsvService : ICsvService
    {
        private readonly ICsvInfraService _csvInfraService;

        public CsvService(ICsvInfraService csvInfraService) => _csvInfraService = csvInfraService;

        public async Task LoadMovieListCsv()
        {
            await _csvInfraService.LoadMovieListCsv();
        }
    }
}
