using Backend_School.WebApi.RabbitMQ;
using Backend_School.WebApi.Services.Interface;
using Backend_School.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Backend_School.WebApi.Helper;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading;
using Backend_School.WebApi.Services.Administrasi;
using Microsoft.AspNetCore.Authorization;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DataConfigPembayaranController : ControllerBase
    {
        public readonly ILogger<LoginController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;

        public DataConfigPembayaranController(ILogger<LoginController> logger, IConfiguration configuration, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("DataConfigPembayaranById")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<DataConfigPembayaranResponse>> DataConfigPembayaranById(IdConfigPembayaranRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _dataConfigPembayaranService.GetIdConfigPembayaran(request, cancellationToken);
            return Ok(ResponseHelper<DataConfigPembayaranResponse>.Create("Successfully get data configurasi pembayaran.", result));
        }

        [Route("DataConfigPembayaranByNama")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<DataConfigPembayaranResponse>> DataConfigPembayaranByNama(NamaConfigPembayaranRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _dataConfigPembayaranService.GetNamaConfigPembayaran(request, cancellationToken);
            return Ok(ResponseHelper<DataConfigPembayaranResponse>.Create("Successfully get data configurasi pembayaran.", result));
        }
    }
}
