using Backend_School.WebApi.Helper;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Backend_School.WebApi.RabbitMQ;
using Backend_School.WebApi.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PembayaranController : ControllerBase
    {
        public readonly ILogger<PembayaranController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IPembayaranService _pembayaranService;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public PembayaranController(ILogger<PembayaranController> logger, IConfiguration configuration, IPembayaranService pembayaranService, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _pembayaranService = pembayaranService;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetPembayaranSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PembayaranResponse>> GetPembayaranSearch(SearchPembayaranRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pembayaranService.GetPembayaranSearch(request, cancellationToken);
            return Ok(ResponseHelper<PembayaranResponse>.Create("Successfully get pembayaran.", result));
        }

        [Route("CheckAddPembayaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PembayaranResponse>> CheckAddPembayaran(CheckPembayaranRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pembayaranService.CheckAddPembayaran(request, cancellationToken);
            return Ok(ResponseHelper<PembayaranResponse>.Create("Successfully check pembayaran.", result));
        }

        [Route("AddPembayaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PembayaranResponse>> AddPembayaran(PembayaranAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _pembayaranService.AddPembayaran(request, cancellationToken);
            return Ok(ResponseHelper<PembayaranResponse>.Create("Successfully add pembayaran.", result));
        }

        [Route("UpdatePembayaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PembayaranResponse>> UpdatePembayaran(PembayaranUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _pembayaranService.EditPembayaran(request, cancellationToken);
            return Ok(ResponseHelper<PembayaranResponse>.Create("Successfully edit pembayaran.", result));
        }
    }
}
