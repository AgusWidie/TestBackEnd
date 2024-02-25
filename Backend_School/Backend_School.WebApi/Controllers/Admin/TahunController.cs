using Backend_School.WebApi.Helper;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.RabbitMQ;
using Backend_School.WebApi.Services;
using Backend_School.WebApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TahunController : ControllerBase
    {
        public readonly ILogger<TahunController> _logger;
        public readonly IConfiguration _configuration;
        public readonly ITahunService _tahunService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;

        public TahunController(ILogger<TahunController> logger, IConfiguration configuration, ITahunService tahunService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _tahunService = tahunService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetTahun")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<TahunResponse>> GetTahun(CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _tahunService.GetTahun(cancellationToken);
            return Ok(ResponseHelper<TahunResponse>.Create("Successfully get tahun.", result));
        }
    }
}
