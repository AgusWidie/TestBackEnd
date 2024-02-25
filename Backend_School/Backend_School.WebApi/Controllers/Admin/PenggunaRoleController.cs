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
    public class PenggunaRoleController : ControllerBase
    {
        public readonly ILogger<PenggunaRoleController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IPenggunaRoleService _penggunaRoleService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public PenggunaRoleController(ILogger<PenggunaRoleController> logger, IConfiguration configuration, IPenggunaRoleService penggunaRoleService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _penggunaRoleService = penggunaRoleService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetPenggunaRoleById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaRoleResponse>> GetPenggunaRoleById(long id, CancellationToken cancellationToken)
        {
            IdPenggunaRoleRequest request = new IdPenggunaRoleRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penggunaRoleService.GetPenggunaRoleById(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaRoleResponse>.Create("Successfully get pengguna role.", result));
        }

        [Route("CheckAddPenggunaRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaRoleResponse>> CheckAddPenggunaRole(CheckPenggunaRoleRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penggunaRoleService.CheckAddPenggunaRole(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaRoleResponse>.Create("Successfully check pengguna role.", result));
        }

        [Route("AddPenggunaRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaRoleResponse>> AddPenggunaRole(PenggunaRoleAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _penggunaRoleService.AddPenggunaRole(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaRoleResponse>.Create("Successfully add pengguna role.", result));
        }

        [Route("UpdatePenggunaRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaRoleResponse>> UpdatePenggunaRole(PenggunaRoleUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _penggunaRoleService.EditPenggunaRole(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaRoleResponse>.Create("Successfully edit pengguna role.", result));
        }

        [Route("DeletePenggunaRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeletePenggunaRole(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _penggunaRoleService.DeletePenggunaRole(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete pengguna role."));
        }
    }
}
