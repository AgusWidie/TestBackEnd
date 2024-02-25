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
    public class JadwalGuruController : ControllerBase
    {
        public readonly ILogger<JadwalGuruController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IJadwalGuruService _jadwalGuruService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;

        public JadwalGuruController(ILogger<JadwalGuruController> logger, IConfiguration configuration, IJadwalGuruService jadwalGuruService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _jadwalGuruService = jadwalGuruService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetJadwalGuruSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<JadwalGuruResponse>> GetJadwalGuruSearch(SearchJadwalGuruRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _jadwalGuruService.GetJadwalGuruSearch(request, cancellationToken);
            return Ok(ResponseHelper<JadwalGuruResponse>.Create("Successfully get jadwal guru.", result));
        }

        [Route("CheckAddJadwalGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<JadwalGuruResponse>> CheckAddJadwalGuru(CheckJadwalGuruRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _jadwalGuruService.CheckAddJadwalGuru(request, cancellationToken);
            return Ok(ResponseHelper<JadwalGuruResponse>.Create("Successfully check jadwal guru.", result));
        }

        [Route("AddJadwalGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<JadwalGuruResponse>> AddJadwalGuru(JadwalGuruAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _jadwalGuruService.AddJadwalGuru(request, cancellationToken);
            return Ok(ResponseHelper<JadwalGuruResponse>.Create("Successfully add jadwal guru.", result));
        }

        [Route("UpdateJadwalGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<JadwalGuruResponse>> UpdateJadwalGuru(JadwalGuruUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _jadwalGuruService.EditJadwalGuru(request, cancellationToken);
            return Ok(ResponseHelper<JadwalGuruResponse>.Create("Successfully update jadwal guru.", result));
        }

        [Route("DeleteJadwalGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteJadwalGuru(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _jadwalGuruService.DeleteJadwalGuru(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete jadwal guru"));
        }
    }
}
