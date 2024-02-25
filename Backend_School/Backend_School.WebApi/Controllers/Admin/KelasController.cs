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
    public class KelasController : ControllerBase
    {
        public readonly ILogger<KelasController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IKelasService _kelasService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public KelasController(ILogger<KelasController> logger, IConfiguration configuration, IKelasService kelasService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _kelasService = kelasService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetKelasById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<KelasResponse>> GetKelasById(long id, CancellationToken cancellationToken)
        {
            IdKelasRequest request = new IdKelasRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _kelasService.GetKelasById(request, cancellationToken);
            return Ok(ResponseHelper<KelasResponse>.Create("Successfully get kelas.", result));
        }

        [Route("GetKelasByPengguna")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<KelasResponse>> GetKelasByPengguna(PenggunaKelasRequest request, CancellationToken cancellationToken)
        {
            request.NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.NamaRole = User.FindFirstValue(ClaimTypes.Role);
            var result = await _kelasService.GetKelasByPengguna(request, cancellationToken);
            return Ok(ResponseHelper<KelasResponse>.Create("Successfully get kelas by pengguna.", result));
        }

        [Route("CheckAddKelas")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<KelasResponse>> CheckAddkelas(CheckKelasRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _kelasService.CheckAddKelas(request, cancellationToken);
            return Ok(ResponseHelper<KelasResponse>.Create("Successfully check kelas.", result));
        }

        [Route("AddKelas")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<KelasResponse>> Addkelas(KelasAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _kelasService.AddKelas(request, cancellationToken);
            return Ok(ResponseHelper<KelasResponse>.Create("Successfully add kelas.", result));
        }

        [Route("UpdateKelas")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<KelasResponse>> Updatekelas(KelasUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _kelasService.EditKelas(request, cancellationToken);
            return Ok(ResponseHelper<KelasResponse>.Create("Successfully update kelas.", result));
        }

        [Route("DeleteKelas")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteKelas(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _kelasService.DeleteKelas(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete kelas."));
        }
    }
}
