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
    public class TahunAjaranController : ControllerBase
    {
        public readonly ILogger<TahunAjaranController> _logger;
        public readonly IConfiguration _configuration;
        public readonly ITahunAjaranService _tahunAjaranService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public TahunAjaranController(ILogger<TahunAjaranController> logger, IConfiguration configuration, ITahunAjaranService tahunAjaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _tahunAjaranService = tahunAjaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetTahunAjaranById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<TahunAjaranResponse>> GetTahunAjaranById(long id, CancellationToken cancellationToken)
        {
            IdTahunAjaranRequest request = new IdTahunAjaranRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _tahunAjaranService.GetTahunAjaranById(request, cancellationToken);
            return Ok(ResponseHelper<TahunAjaranResponse>.Create("Successfully get tahun ajaran.", result));
        }

        [Route("CheckAddTahunAjaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TahunAjaranResponse>> CheckAddTahunAjaran(CheckTahunAjaranRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _tahunAjaranService.CheckAddTahunAjaran(request, cancellationToken);
            return Ok(ResponseHelper<TahunAjaranResponse>.Create("Successfully check tahun ajaran.", result));
        }

        [Route("AddTahunAjaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TahunAjaranResponse>> AddTahunAjaran(TahunAjaranAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _tahunAjaranService.AddTahunAjaran(request, cancellationToken);
            return Ok(ResponseHelper<TahunAjaranResponse>.Create("Successfully add tahun ajaran.", result));
        }

        [Route("UpdateTahunAjaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TahunAjaranResponse>> UpdateTahunAjaran(TahunAjaranUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _tahunAjaranService.EditTahunAjaran(request, cancellationToken);
            return Ok(ResponseHelper<TahunAjaranResponse>.Create("Successfully check tahun ajaran.", result));
        }

        [Route("DeleteTahunAjaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteTahunAjaran(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _tahunAjaranService.DeleteTahunAjaran(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete tahun ajaran."));
        }
    }
}
