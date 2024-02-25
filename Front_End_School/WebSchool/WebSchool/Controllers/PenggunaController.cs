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
    public class PenggunaController : Controller
    {
        private readonly ILogger<PenggunaController> _logger;
        private readonly IPenggunaService _apiPenggunaService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public PenggunaController(ILogger<PenggunaController> logger, IPenggunaService apiPenggunaService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiPenggunaService = apiPenggunaService;
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
        public async Task<GlobalObjectListResponseJson<Pengguna>> ListPengguna(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiPenggunaService.ListPengguna(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddPengguna([FromBody] PenggunaInputModel model, CancellationToken cancellationToken)
        {
            CheckPenggunaModel Check = new CheckPenggunaModel();
            Check.NamaPengguna = model.NamaPengguna;
            Check.IdGuru = model.IdGuru;

            CreateResponse msg = new CreateResponse();

            var CheckData = await _apiPenggunaService.CheckAddPengguna(Check);
            if (CheckData.Error)
            {
                msg.success = false;
                msg.message = CheckData.Message;
                return msg;
            }

            if (CheckData.Data.Any())
            {
                msg.success = false;
                msg.message = "Data Pengguna Sudah Ada...!";
                return msg;
            }

            var apiResponse = await _apiPenggunaService.AddPengguna(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdatePengguna([FromBody] PenggunaUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();
            var apiResponse = await _apiPenggunaService.UpdatePengguna(model, cancellationToken);
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
    }
}
