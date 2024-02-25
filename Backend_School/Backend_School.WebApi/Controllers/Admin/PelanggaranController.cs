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

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PelanggaranController : ControllerBase
    {
        public readonly ILogger<PelanggaranController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IPelanggaranService _pelanggaranService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public PelanggaranController(ILogger<PelanggaranController> logger, IConfiguration configuration, IPelanggaranService pelanggaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _pelanggaranService = pelanggaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetPelanggaranById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<PelanggaranResponse>> GetPelanggaranById(long id, CancellationToken cancellationToken)
        {
            IdPelanggaranRequest request = new IdPelanggaranRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pelanggaranService.GetPelanggaranById(request, cancellationToken);
            return Ok(ResponseHelper<PelanggaranResponse>.Create("Successfully get pelanggaran.", result));
        }

        [Route("CheckAddPelanggaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelanggaranResponse>> CheckAddPelanggaran(CheckPelanggaranRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pelanggaranService.CheckAddPelanggaran(request, cancellationToken);
            return Ok(ResponseHelper<PelanggaranResponse>.Create("Successfully check pelanggaran.", result));
        }

        [Route("AddPelanggaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelanggaranResponse>> AddPelanggaran(PelanggaranAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _pelanggaranService.AddPelanggaran(request, cancellationToken);
            return Ok(ResponseHelper<PelanggaranResponse>.Create("Successfully add pelanggaran.", result));
        }

        [Route("UpdatePelanggaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelanggaranResponse>> UpdatePelanggaran(PelanggaranUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _pelanggaranService.EditPelanggaran(request, cancellationToken);
            return Ok(ResponseHelper<PelanggaranResponse>.Create("Successfully edit pelanggaran.", result));
        }

        [Route("DeletePelanggaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeletePelanggaran(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pelanggaranService.DeletePelanggaran(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete pelanggaran."));
        }
    }
}
