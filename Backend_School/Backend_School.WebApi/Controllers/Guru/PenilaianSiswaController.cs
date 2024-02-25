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
    public class PenilaianSiswaController : ControllerBase
    {
        public readonly ILogger<PenilaianSiswaController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IPenilaianSiswaService _penilaianSiswaService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public PenilaianSiswaController(ILogger<PenilaianSiswaController> logger, IConfiguration configuration, IPenilaianSiswaService penilaianSiswaService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _penilaianSiswaService = penilaianSiswaService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetPenilaianSiswaSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenilaianSiswaResponse>> GetPenilaianSiswaSearch(SearchPenilaianSiswaRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penilaianSiswaService.GetPenilaianSiswaSearch(request, cancellationToken);
            return Ok(ResponseHelper<PenilaianSiswaResponse>.Create("Successfully get penilaian siswa.", result));
        }

        [Route("CheckAddPenilaianSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenilaianSiswaResponse>> CheckAddPenilaianSiswa(CheckPenilaianSiswaRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penilaianSiswaService.CheckAddPenilaianSiswa(request, cancellationToken);
            return Ok(ResponseHelper<PenilaianSiswaResponse>.Create("Successfully check penilaian siswa.", result));
        }

        [Route("AddPenilaianSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenilaianSiswaResponse>> AddPenilaianSiswa(PenilaianSiswaAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _penilaianSiswaService.AddPenilaianSiswa(request, cancellationToken);
            return Ok(ResponseHelper<PenilaianSiswaResponse>.Create("Successfully add penilaian siswa.", result));
        }

        [Route("UpdatePenilaianSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenilaianSiswaResponse>> UpdatePenilaianSiswa(PenilaianSiswaUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _penilaianSiswaService.EditPenilaianSiswa(request, cancellationToken);
            return Ok(ResponseHelper<PenilaianSiswaResponse>.Create("Successfully edit penilaian siswa.", result));
        }

        [Route("DeletePenilaianSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeletePenilaianSiswa(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penilaianSiswaService.DeletePenilaianSiswa(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete penilaian siswa"));
        }
    }
}
