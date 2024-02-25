using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebSchool.Models;
using WebSchool.Service.Interface;


namespace WebSchool.Controllers
{
    public class JadwalPiketGuruController : Controller
    {
        private readonly ILogger<KelasController> _logger;
        private readonly IJadwalPiketGuruService _apiJadwalPiketGuruService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public JadwalPiketGuruController(ILogger<KelasController> logger, IJadwalPiketGuruService apiJadwalPiketGuruService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiJadwalPiketGuruService = apiJadwalPiketGuruService;
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

        [HttpPost]
        public async Task<GlobalObjectListResponseJson<JadwalPiketGuru>> JadwalPiketGuruSearch(SearchJadwalPiketGuru model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiJadwalPiketGuruService.JadwalPiketGuruSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddjadwalPiketGuru([FromBody] JadwalPiketGuruInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                CheckJadwalPiketGuruInputModel Check = new CheckJadwalPiketGuruInputModel();
                Check.IdGuru = model.IdGuru;
                Check.Hari = model.Hari;

                var CheckData = await _apiJadwalPiketGuruService.CheckAddJadwalPiketGuru(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Jadwal Piket Guru Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiJadwalPiketGuruService.AddJadwalPiketGuru(model, cancellationToken);
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
            else
            {
                msg.success = false;
                msg.message = "bad request...!";
                return msg;
            }

        }

        [HttpPost]
        public async Task<UpdateResponse> UpdateJadwalPiketGuru([FromBody] JadwalPiketGuruUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiJadwalPiketGuruService.UpdateJadwalPiketGuru(model, cancellationToken);
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
            else
            {
                msg.success = false;
                msg.message = "bad request...!";
                return msg;
            }

        }

        [HttpPost]
        public async Task<DeleteResponse> DeleteJadwalPiketGuru([FromBody] IdJadwalPiketGuru model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiJadwalPiketGuruService.DeleteJadwalPiketGuru(model, cancellationToken);
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
            else
            {

                msg.success = false;
                msg.message = "bad request...!";
                return msg;
            }

        }
    }
}
