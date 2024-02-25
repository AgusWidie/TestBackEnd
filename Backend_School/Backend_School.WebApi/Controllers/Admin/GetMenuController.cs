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
    public class GetMenuController : ControllerBase
    {
        public readonly ILogger<GetMenuController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IGetMenuService _getMenuService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;

        public GetMenuController(ILogger<GetMenuController> logger, IConfiguration configuration, IGetMenuService getMenuService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _getMenuService = getMenuService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("MenuName")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<MenuResponse>> MenuName(MenuActionRequest request, CancellationToken cancellationToken)
        {

            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _getMenuService.GetMenuController(request, cancellationToken);
            return Ok(ResponseHelper<MenuResponse>.Create("Successfully get menu controller.", result));
        }
    }
}
