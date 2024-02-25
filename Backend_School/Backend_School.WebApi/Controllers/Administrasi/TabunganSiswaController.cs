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
    public class TabunganSiswaController : ControllerBase
    {
        public readonly ILogger<TabunganSiswaController> _logger;
        public readonly IConfiguration _configuration;
        public readonly ITabunganSiswaService _tabunganSiswaService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public TabunganSiswaController(ILogger<TabunganSiswaController> logger, IConfiguration configuration, ITabunganSiswaService tabunganSiswaService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _tabunganSiswaService = tabunganSiswaService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetTabunganSiswaSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TabunganSiswaResponse>> GetTabunganSiswaSearch(SearchTabunganSiswaRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _tabunganSiswaService.GetTabunganSiswaSearch(request, cancellationToken);
            return Ok(ResponseHelper<TabunganSiswaResponse>.Create("Successfully get tabungan siswa.", result));
        }

        [Route("AddTabunganSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TabunganSiswaResponse>> AddTabunganSiswa(TabunganSiswaAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _tabunganSiswaService.AddTabunganSiswa(request, cancellationToken);
            return Ok(ResponseHelper<TabunganSiswaResponse>.Create("Successfully add tabungan siswa.", result));
        }

        [Route("UpdateTabunganSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TabunganSiswaResponse>> UpdateTabunganSiswa(TabunganSiswaUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _tabunganSiswaService.EditTabunganSiswa(request, cancellationToken);
            return Ok(ResponseHelper<TabunganSiswaResponse>.Create("Successfully edit tabungan siswa.", result));
        }

        [Route("DeleteTabunganSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteTabunganSiswa(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _tabunganSiswaService.DeleteTabunganSiswa(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete tabungan siswa."));
        }

        [Route("TotalTabunganSiswa")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TotalTabunganSiswaRsponse>> TotalTabunganSiswa(SearchTabunganSiswaRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _tabunganSiswaService.TotalTabunganSiswa(request, cancellationToken);
            return Ok(ResponseHelper<TotalTabunganSiswaRsponse>.Create("Successfully get total tabungan siswa.", result));
        }
    }
}
