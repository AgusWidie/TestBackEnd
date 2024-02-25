using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Backend_School.WebApi.Models.Request;
using Backend_School.WebApi.Models.Response;
using Microsoft.Extensions.Configuration;
using Backend_School.WebApi.RabbitMQ;
using System.Threading;
using Backend_School.WebApi.Helper;
using System.Security.Claims;
using Backend_School.WebApi.Services.Interface;
using Microsoft.Extensions.Logging;

namespace Backend_School.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public readonly ILogger<TokenController> _logger;
        public readonly IConfiguration _configuration;
        public readonly ITokenService _tokenService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public TokenController(ILogger<TokenController> logger, IConfiguration configuration, ITokenService tokenService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _tokenService = tokenService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("AddToken")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<TokenResponse>> AddToken(TokenAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.NamaPengguna = NamaPengguna;
            request.TanggalBuat = System.DateTime.Now;
            var result = await _tokenService.AddToken(request, cancellationToken);
            return Ok(ResponseHelper<TokenResponse>.Create("Successfully add token.", result));
        }

        [Route("GetCheckToken")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<CheckTokenResponse>> GetCheckToken(CheckTokenRequest request, CancellationToken cancellationToken)
        {
            if (request.ApiKey != _configuration.GetValue<string>("Configuration:ApiKey"))
            {
                return Ok(ResponseHelper.CreateError(400, "Error GetCheckToken."));
            }
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _tokenService.GetCheckToken(request, cancellationToken);
            return Ok(ResponseHelper<CheckTokenResponse>.Create("Successfully check token.", result));
        }
    }
}
