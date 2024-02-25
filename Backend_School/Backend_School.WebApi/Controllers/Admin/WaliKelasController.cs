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
    public class WaliKelasController : ControllerBase
    {
        public readonly ILogger<WaliKelasController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IWaliKelasService _waliKelasService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public WaliKelasController(ILogger<WaliKelasController> logger, IConfiguration configuration, IWaliKelasService waliKelasService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _waliKelasService = waliKelasService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetWaliKelasSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<WaliKelasResponse>> GetWaliKelasSearch(SearchWaliKelasRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _waliKelasService.GetWaliKelasSearch(request, cancellationToken);
            return Ok(ResponseHelper<WaliKelasResponse>.Create("Successfully get wali kelas.", result));
        }

        [Route("CheckAddWaliKelas")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<WaliKelasResponse>> CheckAddWaliKelas(CheckWaliKelasRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _waliKelasService.CheckAddWaliKelas(request, cancellationToken);
            return Ok(ResponseHelper<WaliKelasResponse>.Create("Successfully check wali kelas.", result));
        }

        [Route("AddWaliKelas")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<WaliKelasResponse>> AddWaliKelas(WaliKelasAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _waliKelasService.AddWaliKelas(request, cancellationToken);
            return Ok(ResponseHelper<WaliKelasResponse>.Create("Successfully add wali kelas.", result));
        }

        [Route("UpdateWaliKelas")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<WaliKelasResponse>> UpdateWaliKelas(WaliKelasUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _waliKelasService.EditWaliKelas(request, cancellationToken);
            return Ok(ResponseHelper<WaliKelasResponse>.Create("Successfully add wali kelas.", result));
        }

        [Route("DeleteWaliKelas")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteWaliKelas(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _waliKelasService.DeleteWaliKelas(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete wali kelas."));
        }
    }
}
