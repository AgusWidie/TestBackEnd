using Backend_School.WebApi.Helper;
using Backend_School.WebApi.Models;
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
    public class JadwalPiketGuruController : ControllerBase
    {
        public readonly ILogger<KelasController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IJadwalPiketGuruService _jadwalPiketGuruService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;

        public JadwalPiketGuruController(ILogger<KelasController> logger, IConfiguration configuration, IJadwalPiketGuruService jadwalPiketGuruService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _jadwalPiketGuruService = jadwalPiketGuruService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetJadwalPiketGuruSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<JadwalPiketGuruResponse>> GetJadwalPiketGuruSearch(SearchJadwalPiketGuruRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _jadwalPiketGuruService.GetJadwalPiketGuruSearch(request, cancellationToken);
            return Ok(ResponseHelper<JadwalPiketGuruResponse>.Create("Successfully get jadwal piket guru.", result));
        }

        [Route("CheckAddJadwalPiketGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<JadwalPiketGuruResponse>> CheckAddJadwalPiketGuru(CheckJadwalPiketGuruRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _jadwalPiketGuruService.CheckAddJadwalPiketGuru(request, cancellationToken);
            return Ok(ResponseHelper<JadwalPiketGuruResponse>.Create("Successfully check jadwal piket guru.", result));
        }

        [Route("AddJadwalPiketGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<JadwalPiketGuruResponse>> AddJadwalPiketGuru(JadwalPiketGuruAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _jadwalPiketGuruService.AddJadwalPiket(request, cancellationToken);
            return Ok(ResponseHelper<JadwalPiketGuruResponse>.Create("Successfully add jadwal piket guru.", result));
        }

        [Route("UpdateJadwalPiketGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<JadwalPiketGuruResponse>> UpdateJadwalPiketGuru(JadwalPiketGuruUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _jadwalPiketGuruService.UpdateJadwalPiket(request, cancellationToken);
            return Ok(ResponseHelper<JadwalPiketGuruResponse>.Create("Successfully update jadwal piket guru.", result));
        }

        [Route("DeleteJadwalPiketGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteJadwalPiketGuru(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _jadwalPiketGuruService.DeleteJadwalPiketGuru(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete jadwal piket guru"));
        }
    }
}
