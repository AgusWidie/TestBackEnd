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
    public class JadwalGuruController : Controller
    {
        private readonly ILogger<JadwalGuruController> _logger;
        private readonly IJadwalGuruService _apiJadwalGuruService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public JadwalGuruController(ILogger<JadwalGuruController> logger, IJadwalGuruService apiJadwalGuruService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiJadwalGuruService = apiJadwalGuruService;
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
        public async Task<GlobalObjectListResponseJson<JadwalGuru>> JadwalGuruSearch(SearchJadwalGuru model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiJadwalGuruService.JadwalGuruSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddJadwalGuru([FromBody] JadwalGuruInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                CheckJadwalGuruInputModel Check = new CheckJadwalGuruInputModel();
                Check.IdGuru = model.IdGuru;
                Check.IdKelas = model.IdKelas;
                Check.IdTahunAjaran = model.IdTahunAjaran;
                Check.Hari = model.Hari;
                Check.DariJam = model.DariJam;
                Check.SampaiJam = model.SampaiJam;

                var CheckData = await _apiJadwalGuruService.CheckAddJadwalGuru(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Jadwal Guru Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiJadwalGuruService.AddJadwalGuru(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateJadwalGuru([FromBody] JadwalGuruUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiJadwalGuruService.UpdateJadwalGuru(model, cancellationToken);
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
        public async Task<DeleteResponse> DeleteJadwalGuru([FromBody] IdJadwalGuru model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiJadwalGuruService.DeleteJadwalGuru(model, cancellationToken);
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
