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
    public class PenggunaController : ControllerBase
    {
        public readonly ILogger<PenggunaController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IPenggunaService _penggunaService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public PenggunaController(ILogger<PenggunaController> logger, IConfiguration configuration, IPenggunaService penggunaService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _penggunaService = penggunaService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetPenggunaById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaResponse>> GetPenggunaById(long id, CancellationToken cancellationToken)
        {
            IdPenggunaRequest request = new IdPenggunaRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penggunaService.GetPenggunaById(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaResponse>.Create("Successfully get pengguna.", result));
        }

        [Route("CheckAddPengguna")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaResponse>> CheckAddPengguna(CheckPenggunaRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penggunaService.CheckAddPengguna(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaResponse>.Create("Successfully check pengguna.", result));
        }

        [Route("AddPengguna")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaResponse>> AddPengguna(PenggunaAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _penggunaService.AddPengguna(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaResponse>.Create("Successfully add pengguna.", result));
        }

        [Route("UpdatePengguna")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaResponse>> UpdatePengguna(PenggunaUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _penggunaService.EditPengguna(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaResponse>.Create("Successfully edit pengguna.", result));
        }

        [Route("DeletePengguna")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<GlobalResponse>> DeletePengguna(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penggunaService.DeletePengguna(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete pengguna."));
        }
    }
}
