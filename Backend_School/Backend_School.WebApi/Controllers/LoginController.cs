using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Microsoft.Extensions.Configuration;
using Backend_School.WebApi.RabbitMQ;
using Backend_School.WebApi.Services;
using System.Threading;
using Backend_School.WebApi.Helper;
using Backend_School.WebApi.Models;
using Backend_School.WebApi.Services.Interface;
using Microsoft.Extensions.Logging;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly ILogger<LoginController> _logger;
        public readonly IConfiguration _configuration;
        public readonly ILoginService _loginService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public LoginController(ILogger<LoginController> logger, IConfiguration configuration, ILoginService loginService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _loginService = loginService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("Login")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TokenResponse>> Login(LoginRequest request, CancellationToken cancellationToken)
        {
            if (request.ApiKey != _configuration.GetValue<string>("Configuration:ApiKey"))
            {
                return Ok(ResponseHelper.CreateError(401, "Error Login."));
            }

            var result = await _loginService.Login(request, cancellationToken);
            if (result != null)
            {
                return Ok(ResponseHelper<TokenResponse>.Create("Successfully login.", result));
            }
            else
            {
                return Ok(ResponseHelper.CreateError(500, "Error login."));
            }

        }

        [Route("ConnectDB")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> ConnectDB(ConnectDBRequest request, CancellationToken cancellationToken)
        {
            if (request.ApiKey != _configuration.GetValue<string>("Configuration:ApiKey"))
            {
                return Ok(ResponseHelper.CreateError(401, "Error ConnectDB."));
            }

            var result = await _loginService.ConnectDB(cancellationToken);
            if (result == true)
            {
                return Ok(ResponseHelper.Create("Successfully ConnectDB."));
            }
            else
            {
                return Ok(ResponseHelper.CreateError(500, "Error ConnectDB."));
            }
        }
    }
}
