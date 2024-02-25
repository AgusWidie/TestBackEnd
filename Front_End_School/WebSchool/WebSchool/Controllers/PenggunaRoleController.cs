
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
    public class PenggunaRoleController : Controller
    {
        private readonly ILogger<PenggunaRoleController> _logger;
        private readonly IPenggunaRoleService _apiPenggunaRoleService;
        private readonly IGetMenuService _apiGetMenuService;
        private MenuAction mnuController = new MenuAction();
        public PenggunaRoleController(ILogger<PenggunaRoleController> logger, IPenggunaRoleService apiPenggunaRoleService, IGetMenuService apiGetMenuService)
        {
            _logger = logger;
            _apiPenggunaRoleService = apiPenggunaRoleService;
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
        public async Task<GlobalObjectListResponseJson<PenggunaRole>> ListPenggunaRole(long id, CancellationToken cancellationToken)
        {
            var apiResponse = await _apiPenggunaRoleService.ListPenggunaRole(id, cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<CreateResponse> AddPenggunaRole([FromBody] PenggunaRoleInputModel model, CancellationToken cancellationToken)
        {
            CheckPenggunaRoleModel Check = new CheckPenggunaRoleModel();
            Check.IdPengguna = model.IdPengguna;
            Check.IdRole = model.IdRole;

            CreateResponse msg = new CreateResponse();

            var CheckData = await _apiPenggunaRoleService.CheckAddPenggunaRole(Check);
            if (CheckData.Error)
            {
                msg.success = false;
                msg.message = CheckData.Message;
                return msg;
            }

            if (CheckData.Data.Any())
            {
                msg.success = false;
                msg.message = "Data Pengguna Peran Sudah Ada...!";
                return msg;
            }

            var apiResponse = await _apiPenggunaRoleService.AddPenggunaRole(model, cancellationToken);
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
        public async Task<UpdateResponse> UpdatePenggunaRole([FromBody] PenggunaRoleUpdateModel model, CancellationToken cancellationToken)
        {

            UpdateResponse msg = new UpdateResponse();
            var apiResponse = await _apiPenggunaRoleService.UpdatePenggunaRole(model, cancellationToken);
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
