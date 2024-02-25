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
    public class WaliKelasController : Controller
    {
        private readonly ILogger<WaliKelasController> _logger;
        private readonly IWaliKelasService _apiWaliKelasService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public WaliKelasController(ILogger<WaliKelasController> logger, IWaliKelasService apiWaliKelasService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiWaliKelasService = apiWaliKelasService;
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
        public async Task<GlobalObjectListResponseJson<WaliKelas>> WaliKelasSearch(SearchWaliKelas model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiWaliKelasService.WaliKelasSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddWaliKelas([FromBody] WaliKelasInputModel model, CancellationToken cancellationToken)
        {

            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {
                CheckWaliKelasModel Check = new CheckWaliKelasModel();
                Check.IdGuru = model.IdGuru;
                Check.IdKelas = model.IdKelas;
                Check.IdTahunAjaran = model.IdTahunAjaran;

                var CheckData = await _apiWaliKelasService.CheckAddWaliKelas(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Wali Kelas Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiWaliKelasService.AddWaliKelas(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateWaliKelas([FromBody] WaliKelasUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {
                var apiResponse = await _apiWaliKelasService.UpdateWaliKelas(model, cancellationToken);
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
        public async Task<DeleteResponse> DeleteWaliKelas([FromBody] IdWaliKelas model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiWaliKelasService.DeleteWaliKelas(model, cancellationToken);
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
