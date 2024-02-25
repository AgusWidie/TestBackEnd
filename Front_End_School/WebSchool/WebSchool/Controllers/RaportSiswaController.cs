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
    public class RaportSiswaController : Controller
    {
        private readonly ILogger<RaportSiswaController> _logger;
        private readonly IRaportSiswaService _apiRaportSiswaService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public RaportSiswaController(ILogger<RaportSiswaController> logger, IRaportSiswaService apiRaportSiswaService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiRaportSiswaService = apiRaportSiswaService;
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
        public async Task<GlobalObjectListResponseJson<RaportSiswa>> RaportSiswaSearch(SearchRaportSiswa model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiRaportSiswaService.RaportSiswaSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddRaportSiswa([FromBody] RaportSiswaInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                CheckRaportSiswaModel Check = new CheckRaportSiswaModel();
                Check.IdSiswa = model.IdSiswa;
                Check.IdKelas = model.IdKelas;
                Check.IdTahunAjaran = model.IdTahunAjaran;
                Check.IdPelajaran = model.IdPelajaran;

                var CheckData = await _apiRaportSiswaService.CheckAddRaportSiswa(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Raport Siswa Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiRaportSiswaService.AddRaportSiswa(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateRaportSiswa([FromBody] RaportSiswaUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiRaportSiswaService.UpdateRaportSiswa(model, cancellationToken);
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
        public async Task<DeleteResponse> DeleteRaportSiswa([FromBody] IdRaportSiswa model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiRaportSiswaService.DeleteRaportSiswa(model, cancellationToken);
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
