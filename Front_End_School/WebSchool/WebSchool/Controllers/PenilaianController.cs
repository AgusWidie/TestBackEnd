using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Auth;
using WebSchool.Models;
using WebSchool.Service.Interface;

namespace WebSchool.Controllers
{
    [Authentication]
    public class PenilaianController : Controller
    {
        private readonly ILogger<PenilaianController> _logger;
        private readonly IPenilaianService _apiPenilaianService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public PenilaianController(ILogger<PenilaianController> logger, IPenilaianService apiPenilaianService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiPenilaianService = apiPenilaianService;
            _apiGetMenuService = apiGetMenuService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            try
            {
                string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
                var NamaPengguna = User.FindFirstValue(ClaimTypes.NameIdentifier);
                mnuController.ControllerName = controllerName;
                ViewBag.MenuController = _apiGetMenuService.GetMenuController(mnuController);

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public async Task<GlobalObjectListResponseJson<Penilaian>> ListPenilain(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiPenilaianService.ListPenilaian(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddPenilaian([FromBody] PenilaianInputModel model, CancellationToken cancellationToken)
        {
            CheckPenilaianModel Check = new CheckPenilaianModel();
            Check.IdPelajaran = model.IdPelajaran;
            Check.NamaPenilaian = model.NamaPenilaian;

            CreateResponse msg = new CreateResponse();

            var CheckData = await _apiPenilaianService.CheckAddPenilaian(Check);
            if (CheckData.Error)
            {
                msg.success = false;
                msg.message = CheckData.Message;
                return msg;
            }

            if (CheckData.Data.Any())
            {
                msg.success = false;
                msg.message = "Data Penilaian Sudah Ada...!";
                return msg;
            }

            var apiResponse = await _apiPenilaianService.AddPenilaian(model, cancellationToken);
            if (apiResponse.error)
            {
                msg.success = false;
                msg.message = apiResponse.message;
                return msg;
            }

            msg.success = true;
            msg.message = apiResponse.message;
            return msg;

        }

        [HttpPost]
        public async Task<UpdateResponse> UpdatePenilaian([FromBody] PenilaianUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();
            var apiResponse = await _apiPenilaianService.UpdatePenilaian(model, cancellationToken);
            if (apiResponse.error)
            {
                msg.success = false;
                msg.message = apiResponse.message;
                return msg;
            }

            msg.success = true;
            msg.message = apiResponse.message;
            return msg;

        }
    }
}
