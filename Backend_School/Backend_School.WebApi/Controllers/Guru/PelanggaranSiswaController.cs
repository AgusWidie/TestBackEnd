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
    public class PelanggaranSiswaController : ControllerBase
    {
        public readonly ILogger<PelanggaranSiswaController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IPelanggaranSiswaService _pelanggaranSiswaService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public PelanggaranSiswaController(ILogger<PelanggaranSiswaController> logger, IConfiguration configuration, IPelanggaranSiswaService pelanggaranSiswaService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _pelanggaranSiswaService = pelanggaranSiswaService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetPelanggaranSiswaSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelanggaranSiswaResponse>> GetPelanggaranSiswaSearch(SearchPelanggaranSiswaRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pelanggaranSiswaService.GetPelanggaranSiswaSearch(request, cancellationToken);
            return Ok(ResponseHelper<PelanggaranSiswaResponse>.Create("Successfully get pelanggaran siswa.", result));
        }


        [Route("AddPelanggaranSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelanggaranSiswaResponse>> AddPelanggaranSiswa(PelanggaranSiswaAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _pelanggaranSiswaService.AddPelanggaranSiswa(request, cancellationToken);
            return Ok(ResponseHelper<PelanggaranSiswaResponse>.Create("Successfully add pelanggaran siswa.", result));
        }

        [Route("UpdatePelanggaranSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelanggaranSiswaResponse>> UpdatePelanggaranSiswa(PelanggaranSiswaUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _pelanggaranSiswaService.EditPelanggaranSiswa(request, cancellationToken);
            return Ok(ResponseHelper<PelanggaranSiswaResponse>.Create("Successfully edit pelanggaran siswa.", result));
        }

        [Route("DeletePelanggaranSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeletePelanggaranSiswa(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pelanggaranSiswaService.DeletePelanggaranSiswa(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete pelanggaran siswa"));
        }
    }
}
