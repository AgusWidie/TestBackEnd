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
    public class AbsenGuruController : ControllerBase
    {
        public readonly ILogger<AbsenGuruController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IAbsenGuruService _absenGuruService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public AbsenGuruController(ILogger<AbsenGuruController> logger, IConfiguration configuration, IAbsenGuruService absenGuruService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _absenGuruService = absenGuruService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetAbsenGuruSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AbsenGuruResponse>> GetAbsenGuruSearch(SearchAbsenGuruRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _absenGuruService.GetAbsenGuruSearch(request, cancellationToken);
            return Ok(ResponseHelper<AbsenGuruResponse>.Create("Successfully get absen guru.", result));
        }

        [Route("CheckAddAbsenGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AbsenGuruResponse>> CheckAddAbsenGuru(CheckAbsenGuruRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _absenGuruService.CheckAddAbsenGuru(request, cancellationToken);
            return Ok(ResponseHelper<AbsenGuruResponse>.Create("Successfully check absen guru.", result));
        }

        [Route("AddAbsenGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AbsenGuruResponse>> AddAbsenGuru(AbsenGuruAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _absenGuruService.AddAbsenGuru(request, cancellationToken);
            return Ok(ResponseHelper<AbsenGuruResponse>.Create("Successfully add absen guru.", result));
        }


        [Route("UpdateAbsenGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AbsenGuruResponse>> UpdateAbsenGuru(AbsenGuruUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _absenGuruService.EditAbsenGuru(request, cancellationToken);
            return Ok(ResponseHelper<AbsenGuruResponse>.Create("Successfully edit absen guru.", result));
        }

        [Route("DeleteAbsenGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteAbsenGuru(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _absenGuruService.DeleteAbsenGuru(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete absen guru"));
        }
    }
}
