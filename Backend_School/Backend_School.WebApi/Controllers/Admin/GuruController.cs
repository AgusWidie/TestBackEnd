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
    public class GuruController : ControllerBase
    {
        public readonly ILogger<GuruController> _logger;
        public readonly IConfiguration _configuration;
        public readonly IGuruService _guruService;
        public readonly IMessageProducer _messageProducer;
        public readonly ILogErrorService _logErrorService;
        public GuruController(ILogger<GuruController> logger, IConfiguration configuration, IGuruService guruService, IMessageProducer messageProducer, ILogErrorService logErrorService)
        {
            _logger = logger;
            _configuration = configuration;
            _guruService = guruService;
            _messageProducer = messageProducer;
            _logErrorService = logErrorService;
        }

        [Route("GetGuruById")]
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<GuruResponse>> GetGuruById(long id, CancellationToken cancellationToken)
        {
            IdGuruRequest request = new IdGuruRequest();
            request.Id = id;
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _guruService.GetGuruById(request, cancellationToken);
            return Ok(ResponseHelper<GuruResponse>.Create("Successfully get guru.", result));
        }

        [Route("CheckAddGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GuruResponse>> CheckAddGuru(CheckGuruRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _guruService.CheckAddGuru(request, cancellationToken);
            return Ok(ResponseHelper<GuruResponse>.Create("Successfully check guru.", result));
        }

        [Route("AddGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GuruResponse>> AddGuru(GuruAddRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.NomorIndukPegawai = await _guruService.GenerateNomorIndukPegawai(cancellationToken);
            request.PenggunaBuat = NamaPengguna;
            request.TanggalBuat = DateTime.Now;
            var result = await _guruService.AddGuru(request, cancellationToken);

            GuruAddPhotoRequest guruPhotoRequest = new GuruAddPhotoRequest();
            guruPhotoRequest.NomorIndukPegawai = request.NomorIndukPegawai;
            guruPhotoRequest.FilePhoto = request.FilePhoto;
            result = await _guruService.AddPhotoGuru(guruPhotoRequest, cancellationToken);

            return Ok(ResponseHelper<GuruResponse>.Create("Successfully add guru.", result));
        }

        [Route("UpdateGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GuruResponse>> UpdateGuru(GuruUpdateRequest request, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            request.PenggunaPerbarui = NamaPengguna;
            request.TanggalPerbarui = DateTime.Now;
            var result = await _guruService.EditGuru(request, cancellationToken);

            GuruUpdatePhotoRequest guruPhotoRequest = new GuruUpdatePhotoRequest();
            guruPhotoRequest.NomorIndukPegawai = request.NomorIndukPegawai;
            guruPhotoRequest.FilePhoto = request.FilePhoto;
            result = await _guruService.EditPhotoGuru(guruPhotoRequest, cancellationToken);

            return Ok(ResponseHelper<GuruResponse>.Create("Successfully edit guru.", result));
        }

        [Route("DeleteGuru")]
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<GlobalResponse>> DeleteGuru(long id, CancellationToken cancellationToken)
        {
            var NamaPengguna = User.FindFirstValue(ClaimTypes.Name);
            var result = await _guruService.DeleteGuru(id, cancellationToken);
            return Ok(ResponseHelper.Create("Successfully delete guru."));
        }
    }
}
