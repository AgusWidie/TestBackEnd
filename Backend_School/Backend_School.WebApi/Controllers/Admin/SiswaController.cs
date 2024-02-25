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
    public class SiswaController : ControllerBase
    {
        public readonly ILogger<SiswaController> _logger;
        public readonly IConfiguration _configuration;
        public readonly ISiswaService _siswaService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public SiswaController(ILogger<SiswaController> logger, IConfiguration configuration, ISiswaService siswaService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _siswaService = siswaService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetSiswaSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<SiswaResponse>> GetSiswaSearch(SearchSiswaRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _siswaService.GetSiswaSearch(request, cancellationToken);
            return Ok(ResponseHelper<SiswaResponse>.Create("Successfully get siswa.", result));
        }

        [Route("CheckAddSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<SiswaResponse>> CheckAddSiswa(CheckSiswaRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _siswaService.CheckAddSiswa(request, cancellationToken);
            return Ok(ResponseHelper<SiswaResponse>.Create("Successfully check siswa.", result));
        }

        [Route("AddSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<SiswaResponse>> AddSiswa(SiswaAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            //request.NomorIndukSiswa = await _siswaService.GenerateNomorIndukSiswa(cancellationToken);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _siswaService.AddSiswa(request, cancellationToken);

            SiswaAddPhotoRequest siswaPhotoRequest = new SiswaAddPhotoRequest();
            //siswaPhotoRequest.NomorIndukSiswa = await _siswaService.GenerateNomorIndukSiswa(cancellationToken);
            siswaPhotoRequest.NomorIndukSiswa = request.NomorIndukSiswa;
            siswaPhotoRequest.FilePhoto = request.FilePhoto;
            result = await _siswaService.AddPhotoSiswa(siswaPhotoRequest, cancellationToken);

            return Ok(ResponseHelper<SiswaResponse>.Create("Successfully add siswa.", result));
        }

        [Route("UpdateSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<SiswaResponse>> UpdateSiswa(SiswaUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _siswaService.EditSiswa(request, cancellationToken);

            SiswaUpdatePhotoRequest siswaPhotoRequest = new SiswaUpdatePhotoRequest();
            siswaPhotoRequest.NomorIndukSiswa = request.NomorIndukSiswa;
            siswaPhotoRequest.FilePhoto = request.FilePhoto;
            result = await _siswaService.EditPhotoSiswa(siswaPhotoRequest, cancellationToken);

            return Ok(ResponseHelper<SiswaResponse>.Create("Successfully edit siswa.", result));
        }

        [Route("DeleteSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteSiswa(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _siswaService.DeleteSiswa(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete siswa."));
        }
    }
}
