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
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConfigurasiPembayaranController : ControllerBase
    {
        public readonly ILogger<ConfigurasiPembayaranController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IConfigurasiPembayaranService _configurasiPembayaranService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public ConfigurasiPembayaranController(ILogger<ConfigurasiPembayaranController> logger, IConfiguration configuration, IConfigurasiPembayaranService configurasiPembayaranService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _configurasiPembayaranService = configurasiPembayaranService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetConfigPembayaranById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<ConfigPembayaranResponse>> GetConfigPembayaranById(long id, CancellationToken cancellationToken)
        {
            IdConfigPembayaranRequest request = new IdConfigPembayaranRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _configurasiPembayaranService.GetConfigPembayaranById(request, cancellationToken);
            return Ok(ResponseHelper<ConfigPembayaranResponse>.Create("Successfully get configurasi pembayaran.", result));
        }

        [Route("CheckAddConfigPembayaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<ConfigPembayaranResponse>> CheckAddConfigPembayaran(CheckConfigurasiPembayaranRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _configurasiPembayaranService.CheckAddConfigPembayaran(request, cancellationToken);
            return Ok(ResponseHelper<ConfigPembayaranResponse>.Create("Successfully check configurasi pembayaran.", result));
        }

        [Route("ConfigPembayaranSearch")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<ConfigPembayaranResponse>> ConfigPembayaranSearch(SearchConfigPembayaranRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _configurasiPembayaranService.ConfigPembayaranSearch(request, cancellationToken);
            return Ok(ResponseHelper<ConfigPembayaranResponse>.Create("Successfully search configurasi pembayaran.", result));
        }

        [Route("AddConfigPembayaran")]
        [HttpPost]
        public async Task<ActionResult<ConfigPembayaranResponse>> AddConfigPembayaran(ConfigurasiPembayaranAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = DateTime.Now;
            var result = await _configurasiPembayaranService.AddConfigPembayaran(request, cancellationToken);
            return Ok(ResponseHelper<ConfigPembayaranResponse>.Create("Successfully add configurasi pembayaran.", result));
        }

        [Route("UpdateConfigPembayaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<ConfigPembayaranResponse>> UpdateConfigPembayaran(ConfigurasiPembayaranUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = DateTime.Now;
            var result = await _configurasiPembayaranService.EditConfigPembayaran(request, cancellationToken);
            return Ok(ResponseHelper<ConfigPembayaranResponse>.Create("Successfully edit configurasi pembayaran.", result));
        }

        [Route("DeleteConfigPembayaran")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteConfigPembayaran(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _configurasiPembayaranService.DeleteConfigPembayaran(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete configurasi pembayaran."));
        }
    }
}
