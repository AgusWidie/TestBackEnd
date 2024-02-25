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
    public class AbsenSiswaController : Controller
    {
        private readonly ILogger<AbsenSiswaController> _logger;
        private readonly IAbsenSiswaService _apiAbsenSiswaService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public AbsenSiswaController(ILogger<AbsenSiswaController> logger, IAbsenSiswaService apiAbsenSiswaService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiAbsenSiswaService = apiAbsenSiswaService;
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
        public async Task<GlobalObjectListResponseJson<AbsenSiswa>> AbsenSiswaSearch(SearchAbsenSiswa model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiAbsenSiswaService.AbsenSiswaSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddAbsenSiswa([FromBody] AbsenSiswaInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {

                CheckAddAbsenSiswaModel Check = new CheckAddAbsenSiswaModel();
                Check.IdSiswa = model.IdSiswa;
                Check.IdKelas = model.IdKelas;
                Check.IdTahunAjaran = model.IdTahunAjaran;
                Check.TanggalAbsen = System.DateTime.Now;



                var CheckData = await _apiAbsenSiswaService.CheckAddAbsenSiswa(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Absen Siswa Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiAbsenSiswaService.AddAbsenSiswa(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateAbsenSiswa([FromBody] AbsenSiswaUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiAbsenSiswaService.UpdateAbsenSiswa(model, cancellationToken);
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
