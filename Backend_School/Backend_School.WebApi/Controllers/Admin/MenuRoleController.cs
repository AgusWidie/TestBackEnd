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
    public class MenuRoleController : ControllerBase
    {
        public readonly ILogger<MenuRoleController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IMenuRoleService _menuRoleService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public MenuRoleController(ILogger<MenuRoleController> logger, IConfiguration configuration, IMenuRoleService menuRoleService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _menuRoleService = menuRoleService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetMenuRoleById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<MenuRoleResponse>> GetMenuRoleById(long id, CancellationToken cancellationToken)
        {
            IdMenuRoleRequest request = new IdMenuRoleRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _menuRoleService.GetMenuRoleById(request, cancellationToken);
            return Ok(ResponseHelper<MenuRoleResponse>.Create("Successfully get menu role.", result));
        }

        [Route("CheckAddMenuRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<MenuRoleResponse>> CheckAddMenuRole(CheckMenuRoleRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _menuRoleService.CheckAddMenuRole(request, cancellationToken);
            return Ok(ResponseHelper<MenuRoleResponse>.Create("Successfully check menu role.", result));
        }

        [Route("AddMenuRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<MenuRoleResponse>> AddMenuRole(MenuRoleAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _menuRoleService.AddMenuRole(request, cancellationToken);
            return Ok(ResponseHelper<MenuRoleResponse>.Create("Successfully add menu role.", result));
        }

        [Route("UpdateMenuRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<MenuRoleResponse>> UpdateMenuRole(MenuRoleUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = System.DateTime.Now;
            var result = await _menuRoleService.EditMenuRole(request, cancellationToken);
            return Ok(ResponseHelper<MenuRoleResponse>.Create("Successfully edit menu role.", result));
        }

        [Route("DeleteMenuRole")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteMenuRole(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _menuRoleService.DeleteMenuRole(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete menu role."));
        }
    }
}
