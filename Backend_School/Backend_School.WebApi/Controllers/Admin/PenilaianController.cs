using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Microsoft.Extensions.Configuration;
using Backend_School.WebApi.RabbitMQ;
using Backend_School.WebApi.Services;
using System.Threading;
using Backend_School.WebApi.Helper;
using Microsoft.AspNetCore.Authorization;
using Backend_School.WebApi.Models;
using Backend_School.WebApi.Services.Interface;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PenilaianController : ControllerBase
    {
        public readonly ILogger<PenilaianController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IPenilaianService _penilaianService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public PenilaianController(ILogger<PenilaianController> logger, IConfiguration configuration, IPenilaianService penilaianService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _penilaianService = penilaianService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetPenilaianById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<PenilaianResponse>> GetPenilaianById(long id, CancellationToken cancellationToken)
        {
            IdPenilaianRequest request = new IdPenilaianRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penilaianService.GetPenilaianById(request, cancellationToken);
            return Ok(ResponseHelper<PenilaianResponse>.Create("Successfully get absen siswa.", result));
        }

        [Route("CheckAddPenilaian")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenilaianResponse>> CheckAddPenilaian(CheckPenilaianRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penilaianService.CheckAddPenilaian(request, cancellationToken);
            return Ok(ResponseHelper<PenilaianResponse>.Create("Successfully check penilaian.", result));
        }

        [Route("AddPenilaian")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenilaianResponse>> AddPenilaian(PenilaianAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _penilaianService.AddPenilaian(request, cancellationToken);
            return Ok(ResponseHelper<PenilaianResponse>.Create("Successfully add penilaian.", result));
        }

        [Route("UpdatePenilaian")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenilaianResponse>> UpdatePenilaian(PenilaianUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _penilaianService.EditPenilaian(request, cancellationToken);
            return Ok(ResponseHelper<PenilaianResponse>.Create("Successfully edit penilaian.", result));
        }

        [Route("DeletePenilaian")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeletePenilaian(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penilaianService.DeletePenilaian(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete penilaian."));
        }
    }
}
