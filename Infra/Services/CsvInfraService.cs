using CsvHelper;
using CsvHelper.Configuration;
using GoldenRaspberryAwards.Infra.Entities;
using GoldenRaspberryAwards.Infra.Repository.Interfaces;
using GoldenRaspberryAwards.Infra.Services.Extensions;
using GoldenRaspberryAwards.Infra.Services.Interfaces;
using System.Globalization;

namespace GoldenRaspberryAwards.Infra.Services
{
    public class CsvInfraService : ICsvInfraService
    {
        private readonly IGoldenRaspberryAwardRepository _goldenRaspberryAwardRepository;

        public CsvInfraService(IGoldenRaspberryAwardRepository goldenRaspberryAwardRepository) => _goldenRaspberryAwardRepository = goldenRaspberryAwardRepository;

        public async Task LoadMovieListCsv()
        {
            var csvName = "movielist.csv";

            if (Directory.GetCurrentDirectory().Contains("Test"))
            {
                csvName = "movielist-integration-test.csv";
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", csvName);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";",
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);
            var GoldenRaspberryAwardsCsvRecords = csv.GetRecords<GoldenRaspberryAwardsCsv>().ToList();

            await _goldenRaspberryAwardRepository.SaveGoldenRaspberryAwardAsync(GoldenRaspberryAwardsCsvRecords.GroupBy(_ => _.Year).ToGoldenRaspberryAward());
        }
    }
}
