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
    public class ChangePasswordController : ControllerBase
    {
        public readonly ILogger<ChangePasswordController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IChangePasswordService _changePasswordService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;

        public ChangePasswordController(ILogger<ChangePasswordController> logger, IConfiguration configuration, IChangePasswordService changePasswordService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _changePasswordService = changePasswordService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GantiPassword")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<PenggunaResponse>> GantiPassword(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _changePasswordService.GantiPassword(request, cancellationToken);
            return Ok(ResponseHelper<PenggunaResponse>.Create("Successfully Ganti Password.", result));
        }
    }
}
