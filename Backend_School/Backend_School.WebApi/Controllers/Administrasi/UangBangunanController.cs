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
    public class UangBangunanController : ControllerBase
    {
        public readonly ILogger<UangBangunanController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IUangBangunanService _uangBangunanService;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public UangBangunanController(ILogger<UangBangunanController> logger, IConfiguration configuration, IUangBangunanService uangBangunanService, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _uangBangunanService = uangBangunanService;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetUangBangunanSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<UangBangunanResponse>> GetUangBangunanSearch(SearchUangBangunanRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _uangBangunanService.GetUangBangunanSearch(request, cancellationToken);
            return Ok(ResponseHelper<UangBangunanResponse>.Create("Successfully get uang bangunan.", result));
        }

        [Route("TotalUangBangunan")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TotalUangBangunanResponse>> TotalUangBangunan(TotalUangBangunanRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _uangBangunanService.TotalUangBangunan(request, cancellationToken);
            return Ok(ResponseHelper<TotalUangBangunanResponse>.Create("Successfully Total Uang Bangunan Siswa.", result));
        }

        [Route("AddUangBangunan")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<UangBangunanResponse>> AddUangBangunan(UangBangunanAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _uangBangunanService.AddUangBangunan(request, cancellationToken);
            return Ok(ResponseHelper<UangBangunanResponse>.Create("Successfully add uang bangunan.", result));
        }

        [Route("UpdateUangBangunan")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<UangBangunanResponse>> UpdateUangBangunan(UangBangunanUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _uangBangunanService.EditUangBangunan(request, cancellationToken);
            return Ok(ResponseHelper<UangBangunanResponse>.Create("Successfully edit uang bangunan.", result));
        }

        [Route("DeleteUangBangunan")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteUangBangunan(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _uangBangunanService.DeleteUangBangunan(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete uang bangunan"));
        }
    }
}
