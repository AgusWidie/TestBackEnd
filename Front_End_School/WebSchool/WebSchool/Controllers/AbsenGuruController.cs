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
    public class AbsenGuruController : Controller
    {
        private readonly ILogger<AbsenGuruController> _logger;
        private readonly IAbsenGuruService _apiAbsenGuruService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public AbsenGuruController(ILogger<AbsenGuruController> logger, IAbsenGuruService apiAbsenGuruService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiAbsenGuruService = apiAbsenGuruService;
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
        public async Task<GlobalObjectListResponseJson<AbsenGuru>> AbsenGuruSearch(SearchAbsenGuru model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiAbsenGuruService.AbsenGuruSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddAbsenGuru([FromBody] AbsenGuruInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {

                CheckAddAbsenGuruModel Check = new CheckAddAbsenGuruModel();
                Check.IdGuru = model.IdGuru;
                Check.IdKelas = model.IdKelas;
                Check.IdTahunAjaran = model.IdTahunAjaran;
                Check.TanggalAbsen = System.DateTime.Now;

                var CheckData = await _apiAbsenGuruService.CheckAddAbsenGuru(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Absen Guru Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiAbsenGuruService.AddAbsenGuru(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateAbsenGuru([FromBody] AbsenGuruUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiAbsenGuruService.UpdateAbsenGuru(model, cancellationToken);
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
