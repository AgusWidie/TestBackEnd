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
    public class PelajaranController : ControllerBase
    {
        public readonly ILogger<PelajaranController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IPelajaranService _pelajaranService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public PelajaranController(ILogger<PelajaranController> logger, IConfiguration configuration, IPelajaranService pelajaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _pelajaranService = pelajaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetPelajaranById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<PelajaranResponse>> GetPelajaranById(long id, CancellationToken cancellationToken)
        {
            IdPelajaranRequest request = new IdPelajaranRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pelajaranService.GetPelajaranById(request, cancellationToken);
            return Ok(ResponseHelper<PelajaranResponse>.Create("Successfully get pelajaran.", result));
        }

        [Route("CheckAddPelajaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelajaranResponse>> CheckAddPelajaran(CheckPelajaranRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pelajaranService.CheckAddPelajaran(request, cancellationToken);
            return Ok(ResponseHelper<PelajaranResponse>.Create("Successfully check pelajaran.", result));
        }

        [Route("AddPelajaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelajaranResponse>> AddPelajaran(PelajaranAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _pelajaranService.AddPelajaran(request, cancellationToken);
            return Ok(ResponseHelper<PelajaranResponse>.Create("Successfully add pelajaran.", result));
        }

        [Route("UpdatePelajaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PelajaranResponse>> UpdatePelajaran(PelajaranUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _pelajaranService.EditPelajaran(request, cancellationToken);
            return Ok(ResponseHelper<PelajaranResponse>.Create("Successfully edit pelajaran.", result));
        }

        [Route("DeletePelajaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeletePelajaran(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _pelajaranService.DeletePelajaran(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete pelajaran."));
        }
    }
}
