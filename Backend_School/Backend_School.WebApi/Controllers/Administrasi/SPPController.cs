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

namespace Backend_School.WebApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SPPController : ControllerBase
    {
        public readonly ILogger<SPPController> _logger;
        public readonly IConfiguration _configuration;
        public readonly ISPPService _SPPService;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public SPPController(ILogger<SPPController> logger, IConfiguration configuration, ISPPService SPPService, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _SPPService = SPPService;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }


        [Route("GetSPPSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<SPPResponse>> GetSPPSearch(SearchSPPRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _SPPService.GetSPPSearch(request, cancellationToken);
            return Ok(ResponseHelper<SPPResponse>.Create("Successfully get SPP.", result));
        }

        [Route("CheckAddSPP")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<SPPResponse>> CheckAddSPP(CheckSPPRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _SPPService.CheckAddSPP(request, cancellationToken);
            return Ok(ResponseHelper<SPPResponse>.Create("Successfully check SPP.", result));
        }

        [Route("CheckBulanSPPSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<BulanResponse>> CheckBulanSPPSiswa(CheckSPPRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _SPPService.CheckBulanSPPSiswa(request, cancellationToken);
            return Ok(ResponseHelper<BulanResponse>.Create("Successfully check Bulan SPP Siswa.", result));
        }

        [Route("AddSPP")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<SPPResponse>> AddSPP(SPPAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _SPPService.AddSPP(request, cancellationToken);
            return Ok(ResponseHelper<SPPResponse>.Create("Successfully add SPP.", result));
        }

        [Route("UpdateSPP")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<SPPResponse>> UpdateSPP(SPPUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _SPPService.EditSPP(request, cancellationToken);
            return Ok(ResponseHelper<SPPResponse>.Create("Successfully edit SPP.", result));
        }

        [Route("DeleteSPP")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteSPP(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _SPPService.DeleteSPP(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete SPP"));
        }
    }
}
