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
    public class PembayaranController : Controller
    {
        private readonly ILogger<PembayaranController> _logger;
        private readonly IPembayaranService _apiPembayaranService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public PembayaranController(ILogger<PembayaranController> logger, IPembayaranService apiPembayaranService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiPembayaranService = apiPembayaranService;
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
        public async Task<GlobalObjectListResponseJson<Pembayaran>> PembayaranSearch(SearchPembayaran model, CancellationToken cancellationToken)
        {

            var apiResponse = await _apiPembayaranService.PembayaranSearch(model, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddPembayaran([FromBody] PembayaranInputModel model, CancellationToken cancellationToken)
        {
            CheckPembayaranModel Check = new CheckPembayaranModel();
            Check.IdSiswa = model.IdSiswa;
            Check.IdConfigPembayaran = model.IdConfigPembayaran;


            CreateResponse msg = new CreateResponse();

            var CheckData = await _apiPembayaranService.CheckAddPembayaran(Check);
            if (CheckData.Error)
            {
                msg.success = false;
                msg.message = CheckData.Message;
                return msg;
            }

            if (CheckData.Data.Any())
            {
                msg.success = false;
                msg.message = "Data Pembayaran Siswa Sudah Ada...!";
                return msg;
            }

            var apiResponse = await _apiPembayaranService.AddPembayaran(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdatePembayaran([FromBody] PembayaranUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();
            var apiResponse = await _apiPembayaranService.UpdatePembayaran(model, cancellationToken);
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
        public async Task<DeleteResponse> DeletePembayaran([FromBody] IdPembayaran model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiPembayaranService.DeletePembayaran(model, cancellationToken);
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
