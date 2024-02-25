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
    public class TahunAjaranController : Controller
    {
        private readonly ILogger<TahunAjaranController> _logger;
        private readonly ITahunAjarService _apiTahunAjaranService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public TahunAjaranController(ILogger<TahunAjaranController> logger, ITahunAjarService apiTahunAjaranService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiTahunAjaranService = apiTahunAjaranService;
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
        public async Task<GlobalObjectListResponseJson<TahunAjar>> ListTahunAjaran(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiTahunAjaranService.ListTahunAjaran(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddTahunAjaran([FromBody] TahunAjaranInputModel model, CancellationToken cancellationToken)
        {

            CreateResponse msg = new CreateResponse();

            if(ModelState.IsValid)
            {
                CheckTahunAjaranModel Check = new CheckTahunAjaranModel();
                Check.TahunAjaran = model.TahunAjaran;

                var CheckData = await _apiTahunAjaranService.CheckAddTahunAjaran(Check);
                if (CheckData.Error)
                {
                    msg.success = false;
                    msg.message = CheckData.Message;
                    return msg;
                }

                if (CheckData.Data.Any())
                {
                    msg.success = false;
                    msg.message = "Data Tahun Ajaran Sudah Ada...!";
                    return msg;
                }

                var apiResponse = await _apiTahunAjaranService.AddTahunAjaran(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdateTahunAjaran([FromBody] TahunAjaranUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();

            if(ModelState.IsValid)
            {
                var apiResponse = await _apiTahunAjaranService.UpdateTahunAjaran(model, cancellationToken);
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
