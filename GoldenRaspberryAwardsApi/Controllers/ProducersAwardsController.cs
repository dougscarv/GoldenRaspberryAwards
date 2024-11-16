using GoldenRaspberryAwards.Domain.Models.ProducersAwards;
using GoldenRaspberryAwards.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GoldenRaspberryAwardsApi.Controllers
{
    [ApiController]
    [Route("api/producers/awards")]
    public class ProducersAwardsController : ControllerBase
    {
        private readonly ILogger<ProducersAwardsController> _logger;
        private readonly IGoldenRaspberryAwardServices _goldenRaspberryAwardServices;

        public ProducersAwardsController(ILogger<ProducersAwardsController> logger, IGoldenRaspberryAwardServices goldenRaspberryAwardServices)
        {
            _logger = logger;
            _goldenRaspberryAwardServices = goldenRaspberryAwardServices;
        }

        [HttpGet("interval")]
        public async Task<ProducersAwardsIntervalResponse> GetAwardsInterval()
        {
            return (ProducersAwardsIntervalResponse)await _goldenRaspberryAwardServices.GetAwardsIntervalAsync();
        }
    }
}
