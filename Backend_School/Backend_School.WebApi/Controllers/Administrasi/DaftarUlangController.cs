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
    public class DaftarUlangController : ControllerBase
    {
        public readonly ILogger<DaftarUlangController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IDaftarUlangService _daftarUlangService;
        public readonly IDataConfigPembayaranService _dataConfigPembayaranService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public DaftarUlangController(ILogger<DaftarUlangController> logger, IConfiguration configuration, IDaftarUlangService daftarUlangService, IDataConfigPembayaranService dataConfigPembayaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _daftarUlangService = daftarUlangService;
            _dataConfigPembayaranService = dataConfigPembayaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetDaftarUlangSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<DaftarUlangResponse>> GetDaftarUlangSearch(SearchDaftarUlangRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _daftarUlangService.GetDaftarUlangSearch(request, cancellationToken);
            return Ok(ResponseHelper<DaftarUlangResponse>.Create("Successfully get daftar ulang.", result));
        }

        [Route("CheckAddDaftarUlang")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<DaftarUlangResponse>> CheckAddDaftarUlang(CheckDaftarUlangRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _daftarUlangService.CheckAddDaftarUlang(request, cancellationToken);
            return Ok(ResponseHelper<DaftarUlangResponse>.Create("Successfully check daftar ulang.", result));
        }

        [Route("AddDaftarUlang")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<DaftarUlangResponse>> AddDaftarUlang(DaftarUlangAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _daftarUlangService.AddDaftarUlang(request, cancellationToken);
            return Ok(ResponseHelper<DaftarUlangResponse>.Create("Successfully add daftar ulang.", result));
        }

        [Route("UpdateDaftarUlang")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<DaftarUlangResponse>> UpdateDaftarUlang(DaftarUlangUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _daftarUlangService.EditDaftarUlang(request, cancellationToken);
            return Ok(ResponseHelper<DaftarUlangResponse>.Create("Successfully edit daftar ulang.", result));
        }

        [Route("DeleteDaftarUlang")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteDaftarUlang(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _daftarUlangService.DeleteDaftarUlang(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete daftar ulang"));
        }
    }
}
