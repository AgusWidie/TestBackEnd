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
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AbsenSiswaController : ControllerBase
    {
        public readonly ILogger<AbsenSiswaController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IAbsenSiswaService _absenSiswaService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public AbsenSiswaController(ILogger<AbsenSiswaController> logger, IConfiguration configuration, IAbsenSiswaService absenSiswaService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _absenSiswaService = absenSiswaService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetAbsenSiswaSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AbsenSiswaResponse>> GetAbsenSiswaSearch(SearchAbsenSiswaRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _absenSiswaService.GetAbsenSiswaSearch(request, cancellationToken);
            return Ok(ResponseHelper<AbsenSiswaResponse>.Create("Successfully get absen siswa.", result));
        }

        [Route("CheckAddAbsenSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AbsenSiswaResponse>> CheckAddAbsenSiswa(CheckAbsenSiswaRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _absenSiswaService.CheckAddAbsenSiswa(request, cancellationToken);
            return Ok(ResponseHelper<AbsenSiswaResponse>.Create("Successfully check absen siswa.", result));
        }

        [Route("AddAbsenSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AbsenSiswaResponse>> AddAbsenSiswa(AbsenSiswaAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = DateTime.Now;
            var result = await _absenSiswaService.AddAbsenSiswa(request, cancellationToken);
            return Ok(ResponseHelper<AbsenSiswaResponse>.Create("Successfully add absen siswa.", result));
        }

        [Route("UpdateAbsenSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AbsenSiswaResponse>> EditAbsenSiswa(AbsenSiswaUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = DateTime.Now;
            var result = await _absenSiswaService.EditAbsenSiswa(request, cancellationToken);
            return Ok(ResponseHelper<AbsenSiswaResponse>.Create("Successfully edit absen siswa.", result));
        }


        [Route("DeleteAbsenSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteAbsenSiswa(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _absenSiswaService.DeleteAbsenSiswa(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete absen siswa."));
        }
    }
}
