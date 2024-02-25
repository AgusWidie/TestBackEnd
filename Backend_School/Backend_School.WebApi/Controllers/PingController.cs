using Backend_School.WebApi.Helper;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using Backend_School.WebApi.Models;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        public readonly ILogger<PingController> _logger;
        public readonly ILogErrorService _logErrorService;
        public readonly IConfiguration _configuration;

        public PingController(ILogger<PingController> logger, IConfiguration configuration, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _logErrorService = logErrorService;
        }


        [Route("GetPing")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> GetPing(PingRequest request, CancellationToken cancellationToken)
        {
            if (request.ApiKey != _configuration.GetValue<string>("Configuration:ApiKey")) {
                return Ok(ResponseHelper.CreateError(401, "Error Unauthorize."));
            }

            return Ok(ResponseHelper.Create("Successfully ping."));
        }
    }
}
