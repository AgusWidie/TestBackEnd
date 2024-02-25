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
    public class ConfigurasiPembayaranController : Controller
    {
        private readonly ILogger<ConfigurasiPembayaranController> _logger;
        private readonly IConfigurasiPembayaranService _apiConfigurasiPembayaranService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public ConfigurasiPembayaranController(ILogger<ConfigurasiPembayaranController> logger, IConfigurasiPembayaranService apiConfigurasiPembayaranService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiConfigurasiPembayaranService = apiConfigurasiPembayaranService;
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
        public async Task<GlobalObjectListResponseJson<ConfigurasiPembayaran>> ListConfigurasiPembayaran(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiConfigurasiPembayaranService.ListConfigurasiPembayaran(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<GlobalObjectListResponseJson<ConfigurasiPembayaran>> ConfigurasiPembayaranSearch(SearchConfigPembayaran model, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiConfigurasiPembayaranService.ConfigurasiPembayaranSearch(model, cancellationToken);
            return apiResponse;
        }


        [HttpPost]
        public async Task<CreateResponse> AddConfigurasiPembayaran([FromBody] ConfigurasiPembayaranInputModel model, CancellationToken cancellationToken)
        {
            CreateResponse msg = new CreateResponse();

            if (ModelState.IsValid)
            {

                CheckConfigurasiPembayaranModel Check = new CheckConfigurasiPembayaranModel();
                Check.NamaPembayaran = model.NamaPembayaran;
                Check.IdTahunAjaran = model.IdTahunAjaran;

                var CheckData = await _apiConfigurasiPembayaranService.CheckAddConfigPembayaran(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Configurasi Pembayaran Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiConfigurasiPembayaranService.AddConfigPembayaran(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateConfigurasiPembayaran([FromBody] ConfigurasiPembayaranUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiConfigurasiPembayaranService.UpdateConfigPembayaran(model, cancellationToken);
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
        public async Task<DeleteResponse> DeleteConfigurasiPembayaran([FromBody] IdConfigurasiPembayaran model, CancellationToken cancellationToken)
        {

            DeleteResponse msg = new DeleteResponse();

            if (ModelState.IsValid)
            {

                var apiResponse = await _apiConfigurasiPembayaranService.DeleteConfigurasiPembayaran(model, cancellationToken);
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
