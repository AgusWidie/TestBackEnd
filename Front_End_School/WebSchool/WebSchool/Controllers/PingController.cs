using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using WebSchool.Models;
using WebSchool.Service;
using WebSchool.Service.Interface;

namespace WebSchool.Controllers
{
    public class PingController
    {
        private readonly ILogger<PingController> _logger;
        private readonly IPingService _apiPingService;
        public PingController(ILogger<PingController> logger, IPingService apiPingService)
        {
            _logger = logger;
            _apiPingService = apiPingService;
        }

        [HttpGet]
        public async Task<GlobalResponseJson> GetPing(CancellationToken cancellationToken)
        {
            var apiResponse = await _apiPingService.PingServer(cancellationToken);
            return apiResponse;
        }
    }
}
