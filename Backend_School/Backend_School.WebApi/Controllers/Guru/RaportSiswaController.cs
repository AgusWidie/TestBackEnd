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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RaportSiswaController : ControllerBase
    {
        public readonly ILogger<RaportSiswaController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IRaportSiswaService _raportSiswaService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public RaportSiswaController(ILogger<RaportSiswaController> logger, IConfiguration configuration, IRaportSiswaService raportSiswaService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _raportSiswaService = raportSiswaService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetRaportSiswaSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<RaportSiswaResponse>> GetRaportSiswaSearch(SearchRaportSiswaRequest request, CancellationToken cancellationToken)
        {

            var Username = User.FindFirstValue(JwtRegisteredClaimNames.Sid);
            var result = await _raportSiswaService.GetRaportSiswaSearch(request, cancellationToken);
            return Ok(ResponseHelper<RaportSiswaResponse>.Create("Successfully get raport siswa.", result));
        }

        [Route("CheckAddRaportSiswa")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<RaportSiswaResponse>> CheckAddRaportSiswa(CheckRaportSiswaRequest request, CancellationToken cancellationToken)
        {
            var Username = User.FindFirstValue(JwtRegisteredClaimNames.Sid);
            var result = await _raportSiswaService.CheckAddRaportSiswa(request, cancellationToken);
            return Ok(ResponseHelper<RaportSiswaResponse>.Create("Successfully check raport siswa.", result));
        }

        [Route("AddRaportSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<RaportSiswaResponse>> AddRaportSiswa(RaportSiswaAddRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _raportSiswaService.AddRaportSiswa(request, cancellationToken);
            return Ok(ResponseHelper<RaportSiswaResponse>.Create("Successfully add raport siswa.", result));
        }

        [Route("UpdateRaportSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<RaportSiswaResponse>> UpdateRaportSiswa(RaportSiswaUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _raportSiswaService.EditRaportSiswa(request, cancellationToken);
            return Ok(ResponseHelper<RaportSiswaResponse>.Create("Successfully edit raport siswa.", result));
        }

        [Route("DeleteRaportSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteRaportSiswa(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _raportSiswaService.DeleteRaportSiswa(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete raport siswa"));
        }
    }
}
