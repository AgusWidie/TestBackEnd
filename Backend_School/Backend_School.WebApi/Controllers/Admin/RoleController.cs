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
    public class RoleController : ControllerBase
    {
        public readonly ILogger<RoleController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IRoleService _roleService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public RoleController(ILogger<RoleController> logger, IConfiguration configuration, IRoleService roleService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _roleService = roleService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetRoleById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<RoleResponse>> GetRoleById(long id, CancellationToken cancellationToken)
        {
            IdRoleRequest request = new IdRoleRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _roleService.GetRoleById(request, cancellationToken);
            return Ok(ResponseHelper<RoleResponse>.Create("Successfully get role.", result));
        }

        [Route("CheckAddRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<RoleResponse>> CheckAddRole(CheckRoleRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _roleService.CheckAddRole(request, cancellationToken);
            return Ok(ResponseHelper<RoleResponse>.Create("Successfully check role.", result));
        }

        [Route("AddRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<RoleResponse>> AddRole(RoleAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _roleService.AddRole(request, cancellationToken);
            return Ok(ResponseHelper<RoleResponse>.Create("Successfully add role.", result));
        }

        [Route("UpdateRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<RoleResponse>> UpdateRole(RoleUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _roleService.EditRole(request, cancellationToken);
            return Ok(ResponseHelper<RoleResponse>.Create("Successfully edit role.", result));
        }

        [Route("DeleteRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteRole(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _roleService.DeleteRole(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete role."));
        }
    }
}
