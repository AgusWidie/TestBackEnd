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
using Backend_School.WebApi.Services.Interface;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuPenggunaRoleController : ControllerBase
    {
        public readonly ILogger<MenuPenggunaRoleController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IMenuPenggunaRoleService _menuPenggunaRoleService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public MenuPenggunaRoleController(ILogger<MenuPenggunaRoleController> logger, IConfiguration configuration, IMenuPenggunaRoleService menuPenggunaRoleService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _menuPenggunaRoleService = menuPenggunaRoleService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetMenuHeaderPengguna")]
        [HttpGet]
        public async Task<ActionResult<MenuHeaderResponse>> GetMenuHeaderPengguna(long idPengguna, CancellationToken cancellationToken)
        {
            IdMenuPenggunaRequest request = new IdMenuPenggunaRequest();
            request.IdPengguna = idPengguna;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _menuPenggunaRoleService.GetMenuHeaderPengguna(request, cancellationToken);
            return Ok(ResponseHelper<MenuHeaderResponse>.Create("Successfully get menu header pengguna.", result));
        }

        [Route("GetMenuPengguna")]
        [HttpPost]
        public async Task<ActionResult<MenuResponse>> GetMenuPengguna(CheckTokenRequest request, CancellationToken cancellationToken)
        {

            if (request.ApiKey != _configuration.GetValue<string>("Configuration:ApiKey"))
            {
                return Ok(ResponseHelper.CreateError(400, "Error ApiKey."));
            }

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            NamaPenggunaRequest requestPengguna = new NamaPenggunaRequest();
            requestPengguna.NamaPengguna = request.NamaPengguna;
            var result = await _menuPenggunaRoleService.GetMenuPengguna(requestPengguna, cancellationToken);
            return Ok(ResponseHelper<MenuResponse>.Create("Successfully get menu pengguna.", result));
        }


    }
}
