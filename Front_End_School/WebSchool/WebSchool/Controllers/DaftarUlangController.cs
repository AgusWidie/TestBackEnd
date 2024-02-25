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
    public class DaftarUlangController : Controller
    {
        private readonly ILogger<DaftarUlangController> _logger;
        private readonly IDaftarUlangService _apiDaftarUlangService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public DaftarUlangController(ILogger<DaftarUlangController> logger, IDaftarUlangService apiDaftarUlangService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiDaftarUlangService = apiDaftarUlangService;
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
        public async Task<GlobalObjectListResponseJson<DaftarUlang>> DaftarUlangSearch(SearchDaftarUlang model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiDaftarUlangService.DaftarUlangSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddDaftarUlang([FromBody] DaftarUlangInputModel model, CancellationToken cancellationToken)
        {

            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                CheckDaftarUlangModel Check = new CheckDaftarUlangModel();
                Check.IdSiswa = model.IdSiswa;
                Check.IdTahunAjaran = model.IdTahunAjaran;
                Check.IdTahunAjaranTo = model.IdTahunAjaranTo;

                var CheckData = await _apiDaftarUlangService.CheckAddDaftarUlang(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Daftar Ulang Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiDaftarUlangService.AddDaftarUlang(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateDaftarUlang([FromBody] DaftarUlangUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiDaftarUlangService.UpdateDaftarUlang(model, cancellationToken);
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
        public async Task<DeleteResponse> DeleteDaftarUlang([FromBody] IdDaftarUlang model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiDaftarUlangService.DeleteDaftarUlang(model, cancellationToken);
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
